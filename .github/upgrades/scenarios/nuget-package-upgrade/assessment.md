# NuGet package upgrade assessment

_Mode: **full scan** — exact breaking-change call sites were located across all scoped projects._

## Recommended versions

- **Microsoft.EntityFrameworkCore.Sqlite**: **9.0.23** (unified across 1 project(s)).
- **Microsoft.EntityFrameworkCore.Tools**: **10.0.15** (unified across 1 project(s)).

## Public API changes

> **Types moved (namespace changed) are not removals.** A moved type keeps its name and members;
> the fix is a `using`-directive change, not a rewrite. Do not treat a moved type as deleted.

- **Microsoft.EntityFrameworkCore.Sqlite**: no source-breaking public API changes detected — see [`apidiff/Microsoft.EntityFrameworkCore.Sqlite.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.Sqlite.apidiff.md).
- **Microsoft.EntityFrameworkCore.Tools**: no source-breaking public API changes detected — see [`apidiff/Microsoft.EntityFrameworkCore.Tools.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.Tools.apidiff.md).

## Breaking-change findings

- Usages of removed API (PkgApi.0001): 0
- Usages of signature-changed API (PkgApi.0002): 0
- Version divergence findings (Pkg.0003): 0
- Requested-version-unsupported findings (Pkg.0002): 0

Exact call-site locations are available via `query_dotnet_assessment` (list issues per project/file).

## Next steps

1. Proceed to planning to triage the API changes above and plan the code fixes (if any).

