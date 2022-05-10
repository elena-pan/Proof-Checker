# Jeorje
An automated proof checker named after Curious George, the monkey.

Jeorje is an automated proof checker that verifies correctness of proofs in natural deduction, with some type-checking. 

It uses maximal munch to scan input tokens in predicate logic, and then uses a modified version of the shunting yard algorithm to generate a parse tree. Then, rules are checked to ensure correct usage. A symbol table is created to track variables and check for scoped rules, such as implications and forall statements.
