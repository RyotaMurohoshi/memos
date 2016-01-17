

# KotlinのプロパティをJavaで呼ぶ

原則、以下のルール

* Kotlinのxxxというプロパティは、JavaからgetXxx()、setXxx(a)でアクセスできる。(name,enabled,isenabled3)

ただし、Kotlinのプロパティがキャメルケースorスネークケースで分割され、かつ先頭がisの場合、例外ルールが適用される。

* KotlinのプロパティがisXxxの形式であれば、JavaからisXxx()、setXxx(a)でアクセスできる(isString0,isEnabled1)
* Kotlinのプロパティがis_xxxの形式であれば、Javaからis_xxx()、set_xxx(a)でアクセスできる(is_string1,is_enabled2)

また、isxxxでは上記の例外ルールされない点に注意。

* Kotlinのisenabled3というプロパティは、JavaからはgetIsenabled3()、setIsenabled3(a)でアクセスできる。(Isenabled3()、setIsenabled3(a)ではない。)

また

* is_xxx、isXxxのルールが適用されるKotlinのプロパティの型はBooleanに限定されない

# JavaのGetterとSetterをKotlinで呼ぶ

Javaで適切な名前で

* getterのみ
* getterとsetterのみ

が定義されている場合、JavaのGetter・SetterをKotlin側からプロパティ形式で呼び出すことができる。

setterのみの場合Kotlinからプロパティ形式での呼び出しはできない(公式ドキュメントにも記載あり)

## Getterのみ

* data.getXxx() -> d.xxx
* data.isXxx() -> d.isXxx
* data.is_xxx() -> d.is_xxx
* data.get_xxx() -> d._xxx

data.isxxx()とdata.getxxx()では、プロパティ形式のアクセスができなかった

## GetterとSetter

プロパティの形式に対応するGetterとSetterが揃う必要がある

* data.getXxx() と data.setXxx(a) -> data.xxx
* data.isXxx() と data.setXxx(a) -> data.isXxx
* data.is_xxx() と data.set_xxx(a) -> data.is_xxx
* data.get_xxx() と data.set_xxx(a) -> data._xxx

# GroovyのプロパティをJavaで呼ぶ

原則、以下のルール

* Groovyのxxxというプロパティは、JavaからgetXxx()、setXxx(a)でアクセスできる。

ただし、次の例外もある
 
* プロパティがboolean型の場合、getXxxに加えisXxxというgetterもできる。

# JavaのGetterとSetterをGroovyで呼ぶ

Kotlinと違い、SetterのみがJavaで定義されていても、プロパティ形式でアクセス可。
SetterとGetterが独立している。
ただしisXxx()の形式に対応はしていない。
 

Javaのdata.isXxx()というメソッドがあっても、data.isXxxとはアクセスできない。