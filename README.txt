Write a program in c# (using TDD) that can filter a list of strings. It should pass only six letter
strings that are composed of two concatenated smaller strings that are also in the list.

For example, given the list

al, albums, aver, bar, barely, be, befoul, bums, by, cat, con, convex, ely, foul,
here, hereby, jig, jigsaw, or, saw, tail, tailor, vex, we, weaver

The program should return

albums, barely, befoul, convex, hereby, jigsaw, tailor, weaver

Because these are a concatenation of two other strings:

al + bums => albums
bar + ely => barely
be + foul => befoul
con + vex => convex
here + by => hereby
jig + saw => jigsaw
tail + or => tailor
we + aver => weaver

Ref: http://codekata.pragprog.com/2007/01/kata_eight_conf.html