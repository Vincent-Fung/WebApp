using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using systemLog;
using WebApp.Data;
using WebApp.Models;
using WebApp.Pages;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebApp
{
    public class Web : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        Log writelog = new Log();

        public Web(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Company> Companies { get; set; }

        public async Task OnGetAsync()
        {
            Companies = await _context.Companies.ToListAsync();
        }


        public string Message { get; set; }


        // ----------------------------
        //  POST: Neuen Datensatz anlegen
        // ----------------------------
        public async Task<IActionResult> OnPostCreateAsync([FromBody] Company newCompany)
        {
            try
            {
                if (newCompany == null) return BadRequest("Keine Daten empfangen.");

                // Optional: Validierung
                if (string.IsNullOrWhiteSpace(newCompany.NAME))
                    return BadRequest("Name darf nicht leer sein.");

                _context.Companies.Add(newCompany);

                await _context.SaveChangesAsync();

                JsonResult returnData = new JsonResult(newCompany);
                WriteLog("create", newCompany, newCompany);

                return returnData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Anlegen.");
                return StatusCode(500, "Serverfehler: " + ex.Message);
            }
        }

        // ----------------------------
        //  POST: Datensatz bearbeiten
        // ----------------------------
        public async Task<IActionResult> OnPostEditAsync([FromBody] Company edited)
        {
            try
            {
                if (edited == null) return BadRequest("Keine Daten empfangen.");

                var existing = await _context.Companies.FindAsync(edited.ID);
                if (existing == null) return NotFound($"Eintrag {edited.ID} nicht gefunden.");

                Company temp = new Company();
                temp.ID = existing.ID;
                temp.NAME = existing.NAME;
                temp.AGE = existing.AGE;
                temp.ADDRESS = existing.ADDRESS;
                temp.SALARY = existing.SALARY;

                existing.NAME = edited.NAME;
                existing.AGE = edited.AGE;
                existing.ADDRESS = edited.ADDRESS;
                existing.SALARY = edited.SALARY;

                await _context.SaveChangesAsync();
                JsonResult returnData = new JsonResult(existing);
                WriteLog("edit", existing, temp);

                return returnData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Bearbeiten.");
                return StatusCode(500, ex.Message);
            }
        }


        // Hilfsklasse für Delete-Request (sicherer als primitives int from body)
        public class IdRequest { public int Id { get; set; } }


        // ----------------------------
        //  POST: Datensatz löschen
        // ----------------------------
        public async Task<IActionResult> OnPostDeleteAsync([FromBody] IdRequest req)
        {
            try
            {
                if (req == null) return BadRequest("Keine ID übergeben.");

                var existing = await _context.Companies.FindAsync(req.Id);
                if (existing == null) return NotFound($"Eintrag {req.Id} nicht gefunden.");

                Company temp = existing;
                _context.Companies.Remove(existing);
                await _context.SaveChangesAsync();

                JsonResult returnData = new JsonResult(new { DeletedId = req.Id });
                temp.ID = req.Id;
                WriteLog("delete", existing, temp);

                return returnData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Löschen.");
                return StatusCode(500, ex.Message);
            }
        }
        public void WriteLog(string mod, Company edited, Company existing)
        {
            string text;
            switch (mod)
            {

               case "edit":         
                    
                    if (edited.NAME != existing.NAME)
                    {
                        text = "Datensatz geändert von ID: " + edited.ID.ToString() +
                         " | NAME: von " + existing.NAME + " nach " + edited.NAME;
                        writelog.WriteLog(text);
                    }
                    if (edited.SALARY != existing.SALARY)
                    {
                        text = "Datensatz geändert von ID: " + edited.ID.ToString() +
                         " | SALARY: von " + existing.SALARY.ToString() + " nach " + edited.SALARY.ToString();
                        writelog.WriteLog(text);
                    }
                    if (edited.ADDRESS != existing.ADDRESS)
                    {
                        text = "Datensatz geändert von ID: " + edited.ID.ToString() +
                         " | ADDRESS: von " + existing.ADDRESS + " nach " + edited.ADDRESS;
                        writelog.WriteLog(text);
                    }
                    if (edited.AGE != existing.AGE)
                    {
                        text = "Datensatz geändert von ID: " + edited.ID.ToString() +
                         " | AGE: von " + existing.AGE.ToString() + " nach " + edited.AGE.ToString();
                        writelog.WriteLog(text);
                    }
                    break;

               case "delete":
                    text = "Datensatz mit der ID: " + existing.ID.ToString() +
                                 " | mit der Name: " + existing.NAME + " ist wird gelöscht";
                    writelog.WriteLog(text);
                    break;

               case "create":
                    text = "Datensatz mit ID: " + existing.ID.ToString() +
                    " | NAME: " + existing.NAME +
                    " | SALARY: " + existing.SALARY +
                    " | ADDRESS: " + existing.ADDRESS +
                    " erzeugt";
                    writelog.WriteLog(text);

                   break;

            default:
                    break;
            }


        }


        // Diese Funktion wird über den Button aufgerufen
        public string GetServerMessage()
        {
            return $"Hallo! Der Server hat deine Anfrage um {DateTime.Now:T} erhalten.";
        }

        // Handler für den Button-Aufruf
        public IActionResult OnPostCallFunction()
        {
            var message = GetServerMessage();
            string log = "Button wurde geklickt. " + message;
            writelog.WriteLog(log);
            return Content(message); // Gibt reinen Text zurück
        }



    }

}
