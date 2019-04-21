# APPPInCSharp_StatePattern

無瑕的程式碼 : 物件導向原則、設計模式與C#實踐 Agile Principles, Patterns, and Practices in C#

## SMC (State Machine Compiler)

* [unclebob/smcjava](https://github.com/unclebob/smcjava)
* RUNNING SMC -> java -classpath [smc.jar path] smc.Smc -g [language generator] [.sm file name]
  * Ex: java -classpath .\smc.jar smc.Smc -g smc.generator.csharp.SMCSharpGenerator turnstile.sm
  * ![](https://i.imgur.com/JqIB3sa.png)

### #Precondition

* turnstile.sm
* TurnstileActions.cs
* TurnstileFSM.cs
* FSMError.cs [optional]