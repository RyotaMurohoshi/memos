# Javaのバージョニング問題
# の話しよっか
#### 室星亮太
#### 2016/01/21(木) 第1回 ゆるゆる高専エンジニアLT大会 at FULLER
 
---

# 突然ですが問題です

---

#### このクラスを含むライブラリがあります(core_v1.jar)

```java
package com.mrstar.versioning_problem.core;

public final class Core {
    private Core() {}

    public static String getTitle() {
        return "ほげふが";
    }

    public final static String MESSAGE = "ぴよぴよ！";
}
```

---

#### さっきのライブラリに依存するライブラリがあります(framework.jar)

```java
package com.mrstar.versioning_problem.framework;
import com.mrstar.versioning_problem.core.Core;

public class Framework {
    private Framework(){ }
    public static void showTitle() {
        System.out.println(Core.getTitle());
    }
    public static void showMessage() {
        System.out.println(Core.MESSAGE);
    }
}
```

---

![fit](image0.png)

---

#### こんな感じで使います

```java
package com.mrstar;
import com.mrstar.versioning_problem.framework.Framework;

public class Main {
    public static void main(String[] args) {
        Framework.showTitle();
        Framework.showMessage();
    }
}
```

---

#### 実行すると．．．

```java
package com.mrstar;
import com.mrstar.versioning_problem.framework.Framework;

public class Main {
    public static void main(String[] args) {
        Framework.showTitle(); // 「ほげふが」って表示される
        Framework.showMessage(); // 「ぴよぴよ！」って表示される
    }
}
```


---

# こっからがポイントです
#### もうちょっと状況説明が続きます

---

#### 仮の文言を本番用に変更し、バージョンアップ（core_v2.jar）

```java
package com.mrstar.versioning_problem.core;

public final class Core {
    private Core() {}

    public static String getTitle() {
        return "メインページ"; //　さっきまで「ほげふが」
    }
    // さっきまで「ぴよぴよ！」
    public final static String MESSAGE = "こんにちは！";
}
```

---

![fit](image1.png)

---

### core_v2.jarに置き換えて、framework.jarはそのままで

```java
package com.mrstar;
import com.mrstar.versioning_problem.framework.Framework;

public class Main {
    public static void main(String[] args) {
        Framework.showTitle(); // Q1 なんて表示される？
        Framework.showMessage(); // Q2 なんて表示される？
    }
}
```

---

# Q1 「Framework.showTitle();」

* 「ほげふが」って表示されると思う人？
* 「メインページ」って表示されると思う人？

---

# Q2 「Framework.showMessage();」


* 「ぴよぴよ！」って表示されると思う人？
* 「こんにちは！」って表示されると思う人？

---

#[fit]答え合わせ！

---

## Q1 Framework.showTitle()は
## 「メインページ」って表示されます
#### 　
## Q2 Framework.showMessage()は
## 「ぴよぴよ！」って表示されます

---

#[fit]あってた？

---

# 解説！

---

#### framework.jarのFramework.java(再掲)

```java
package com.mrstar.versioning_problem.framework;
import com.mrstar.versioning_problem.core.Core;

public class Framework {
    private Framework(){ }
    public static void showTitle() {
        System.out.println(Core.getTitle());
    }
    public static void showMessage() {
        System.out.println(Core.MESSAGE);
    }
}
```

---

### これをコンパイルした結果がポイント！
### framework.jarの中身をデコンパイルすると．．．

---

#### デコンパイルしたFramework.class

```java
package com.mrstar.versioning_problem.framework;
import com.mrstar.versioning_problem.core.Core;

public class Framework {
    private Framework() {}
    public static void showTitle() {
        System.out.println(Core.getTitle());
    }
    public static void showMessage() {
        System.out.println("ぴよぴよ！");
    }
}
```

---

# 気づいた？
# もう一回みてみましょう！

---

#### Framework.javaのコード

```java
package com.mrstar.versioning_problem.framework;
import com.mrstar.versioning_problem.core.Core;

public class Framework {
    private Framework(){ }
    public static void showTitle() {
        System.out.println(Core.getTitle());
    }
    public static void showMessage() {
        System.out.println(Core.MESSAGE);
    }
}
```

---

#### デコンパイルしたFramework.class

```java
package com.mrstar.versioning_problem.framework;
import com.mrstar.versioning_problem.core.Core;

public class Framework {
    private Framework() {}
    public static void showTitle() {
        System.out.println(Core.getTitle());
    }
    public static void showMessage() {
        System.out.println("ぴよぴよ！");
    }
}
```

---

# おわかりいただけましたか？

---

### デコンパイルした.class
### Core.MESSAGEの文字列リテラルの「ぴよぴよ」
### 直接埋め込まれていましたね！

---

## Core.MESSAGEの文字列リテラル、
## 直接埋め込まれていましたね！

---

## public static final String MESSAGE (略)
## 直接埋め込まれていましたね！

---

# バージョニング問題！
#### 用語自体はC#のもの

---

## public static final intやpublic static final String
## 等クラス定数の箇所はコンパイルすると
## 数値・文字列リテラルに展開されます！

---

### framework.jarは
### core_v1.jarに依存しビルドしました
### その後、再ビルドしませんでしたね

---

### framework.jarを再ビルドするまで、Framewarkクラス内の
### Coreクラスの定数Core.MESSAGEを使っている箇所は
### core_v1の「ぴよぴよ」のままです

---

### 想像してください！
### 製品版のプログラムでテスト用の文言が出てきてしまうのを！

---

# ((((；ﾟДﾟ))))

---

# まぁぶっちゃけ
# ピヨピヨ
# とか、かわいいもんだよね(汗)

---

## 「ここに射幸心をジャブジャブ煽る文言」
#### 笑えないね

---

#### ポイントおさらい
### public static final intみたいな定数は
### コンパイルするとリテラルとして展開される

#### ※プリミティブ型とString型

---

### 「framework.jar再ビルドすりゃよくね？」
### まぁそうなんだけど、Java書くならこれは知っといてほしい
### 定数が埋め込まれて思わぬバグの原因になるから！

---

### 遅くなりましたが自己紹介
* 室星亮太
* 最初はJavaでAndroid (2016年でもJava6 orz)
* 最近までC#でUnity (2016年でもC#3.0(一部4.0) orz)
* 今はTypeScriptでNode.js (JavaScriptむずいね)

---

### 「バージョニング問題、稀なケースなんでしょ？」

---


## わたしもそう思っていた時期がありました。

---

## 去年遭遇しました

### Unity + Android + ある広告SDKで

---

# またまた問題です！
### 今度はAndroid経験者が対象
---

# Androidでpublic static final int
# なよく使うやつってな〜んだ！？

---

# Rクラス

---

### `R.layout.activity_main`のようなリソースID
#### レイアウトや画像に振られるリソースID(intな定数)
#### Rクラスのパッケージ名はアプリのパッケージ名に

---

### RクラスのリソースID利用例

```java
public class MainActivity extends Activity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // これ！！！ビルドすると整数リテラルに
        setContentView(R.layout.activity_main);
    }
}
```

---

### Unity + Android + ある広告SDKで
### バージョニング問題が原因の不具合に遭遇！

---

## Unity+Android+ある広告SDKの構成例
#### これはUnity4までのやり方で現在は非推奨

---

![fit,original](image2.png)

---

![fit](image2.png)

## レイアウトのXMLや画像などのリソース
## 上記リソースを使う広告表示機能のjar
## (AndroidManifest.xml)

---

### jarの中のクラスでは、`R.layout.activity_main`
### みたいなリソースIDの定数、リテラルとして展開されてるよね！

---

### Unityはビルド時、Androidのアプリを作るため
### 新たにAndroidプロジェクトを作って 
### このタイミングでリソースに再度リソースIDが振られます

----

![fit](image2.png)

---

![fit](image2.png)

### jarの中のクラスでは、`R.layout.activity_main`
### みたいなリソースIDの定数、リテラルとして展開されてるよね！

---

#[fit]もし

---

# プラグインが二つになったら


---

![fit,original](image3.png)

---

![fit](image3.png)

# プラグインが二つになったら

---

## この状態でAndroidプロジェクトを作り
## リソースIDを振り直したら

---
## プラグインのJarの中の整数リテラルと
## Unityが新たに作るリソースIDの整数が
## ずれる！

---

# 実行時エラー！

---

#### タチが悪い

---

### public static final intがベタ書きされた
### jarを作ったSDK開発者が悪い！
#### jarの中のリソースIDとUnityが作るAndroidプロジェクトのリソースIDとが一致しない！

---

#### 最悪、非常にギルティ

---

# さてさて、
# バージョニング問題
# 理解してもらえましたか？

---

# みんなバージョニング問題を
# 引き起こしそうなライブラリ
# 作っちゃいけませんよ！

---

# 約束な！

---

## Javaのバージョニング問題の話しよっか
####　
#### 室星亮太
#### 2016/01/21(木) 第1回 ゆるゆる高専エンジニアLT大会 at FULLER
