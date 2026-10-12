# AGENTS.md progress-file correction - Q4 (2026-10-12)

Status: implemented on `docs/agent-instructions-progress-file-fix-q4`; owner review required. Not merged.
Base: `sow/2026-Q4` at `204ce2f9b3416b5ea5f4050fd9758f4011c4ccd1`.
PR: the live PR for this branch in `SAM-BIM/SAM_Python` (its number is not committed here).
Tested content SHA: `2b7aa475ff86f50dad6bcd0fa5d7181dd0ac19a2` (changes only AGENTS.md).
Final PR head and hosted check results: recorded in the live PR description. A record cannot contain its own commit SHA, so this file is the only change after the tested SHA.

## Problem and change

The rollout PR for this repository (`docs/Agent-Continuity-Rollout-Q4.md`) wrote `AGENTS.md` for a repository without `PROJECT_PROGRESS.md`. The owner then authorized creating it, and the post-merge closeout did. `AGENTS.md` therefore still claimed the file was missing and asked the next session to request bootstrap approval.

Three passages are corrected in `AGENTS.md`, each verified to occur exactly once before replacement:

- Before starting work, step 2 now reads the headings of the existing `PROJECT_PROGRESS.md` and the latest dated Q4 closeout (the shared wording used by the other repositories).
- The Project continuity opening paragraph now states the standard post-merge-only closeout rule instead of the missing-file and bootstrap-approval text.
- The Branch context note keeps its accurate statement that no bootstrap files existed when the branch was created, and adds that `PROJECT_PROGRESS.md` was created later on 2026-10-12 by the rollout closeout.

The historical rollout record `docs/Agent-Continuity-Rollout-Q4.md` still describes the repository as it was when that PR was open; it is not edited and is superseded by this record and the progress file.

## Scope

Documentation only. `PROJECT_PROGRESS.md`, product code, workflows, dependency pins and tools are not changed on this branch; its closeout follows merge.

## Validation

Local, documentation checks only (no product build or test was run, none applies):

```bash
base=204ce2f9b3416b5ea5f4050fd9758f4011c4ccd1
tested=2b7aa475ff86f50dad6bcd0fa5d7181dd0ac19a2
final=$(git rev-parse HEAD)   # must equal the final head in the PR description
for revision in "$tested" "$final"; do
  git diff --check "$base" "$revision"; echo "check $revision exit=$?"
  git diff --name-only "$base" "$revision"
  git diff --quiet "$base" "$revision" -- PROJECT_PROGRESS.md; echo "progress $revision exit=$?"
done
git diff --name-only "$tested" "$final"
git show "$final":AGENTS.md | grep -inE 'no .?PROJECT_PROGRESS.md.? (yet|on)|authorize creating|ask the owner whether'   # expect no output
```

Expected: every `exit=` is 0; the full-PR file lists contain only AGENTS.md (at the tested SHA) and AGENTS.md plus this record (at the final head); the tested-to-final list contains only this record; the grep prints nothing.

Result at the tested SHA (2026-10-12, Windows, Git for Windows): `git diff --check` exit=0; changed files: AGENTS.md; stale-phrase matches remaining: 0. The same checks at the final head and the hosted PR checks are reported in the PR description; they are not asserted here.

## Remaining decisions and next step

- Merge needs owner approval, passing final-head checks and resolved/accepted review findings.
- After merge: a docs-only `[skip ci]` closeout entry in `PROJECT_PROGRESS.md` on `sow/2026-Q4` with the merge SHA, then guarded cleanup of `docs/agent-instructions-progress-file-fix-q4` per `AGENTS.md`.