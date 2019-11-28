# Bank Kata (Outside-In/Mockist/London TDD)
## https://katalyst.codurance.com/bank

Interested in the Inside-Out/Classicist/Chicago TDD approach to this Kata? [Here!](https://github.com/karam94/BankKataInsideOut) *(Coming Soon)*

---

In order to try this Kata out yourself with an Outside-In approach:
* Understand the Kata by reading the link above.
* Start with an Acceptance Test that tests whether the system produces the overall Desired Behaviour (Date, Amount, Balance + Correct Outputs).
* Obviously it will not, so start by creating and calling the scaffolding methods that should lead to the Desired Behaviour (`account.Deposit(1000)` etc.) within the Acceptance Test.
* Running your Acceptance Test will result in NotImplementedExceptions firing left, right & center.
* Work inwards from the outside by writing tests around each method you start to implement.
* Once each requirement is implemented, running the Acceptance Test should eventually turn fully green and you've tested the rest of your units in the process!

**Note:** If you spot any improvements/refactorings, let me know or submit a PR! :)
