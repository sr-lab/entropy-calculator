# Entropy Calculator
Extensible batch password entropy calculator.

```
Usage: EntropyCalculator <input_file> [-c|-s|-l|-d|-u]
-c: Per-character Shannon entropy mode
-s: Shannon entropy mode
-l: Length-only mode
-d: Distinct-character mode
-u: LUDS mode
```

## Overview
This utility will take a text files as input and calculate some score for each string contained in it, one per line. For example, given an input file like this:

```
123456
password
12345678
qwerty
123456789
12345
1234
111111
1234567
dragon
...
```

We'll get something like this:

```
password, score
123456, 15.5097750043269
password, 22
12345678, 24
qwerty, 15.5097750043269
123456789, 28.5293250129808
12345, 11.6096404744368
1234, 8
111111, 0
1234567, 19.6514844544032
dragon, 15.5097750043269
...
```

## Scoring Modes
The program has a number of different scoring modes. Currently `-s` is the default:

* -c: Per-character Shannon entropy mode
* -s: Shannon entropy mode, equivalent to `-c` multiplied by the string length (`-l`).
* -l: Given a string of length `n` returns `n`.
* -d: Given a string containing `k` distinct characters (e.g. for `aabc123` then `k=6`) returns `k`.
* -u: Given a string containing `j` LUDS character classes (lower, upper, digit, symbol) returns `j`.
