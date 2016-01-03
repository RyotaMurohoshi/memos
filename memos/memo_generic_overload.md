# C#のジェネリックなオーバーロードの解決

Interactive ExtensionsのジェネリックなRepeatメソッドのオーバーロードの解決に関する気付きのメモ

## 対象のオーバーロードの紹介
Repeatメソッドは幾つか種類があるけど、今回対象は二つ

### その1

```csharp
public static IEnumerable<TResult> Repeat<TResult>(TResult value)
```

コードは[こちら](https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L172)

### その2

```csharp
public static IEnumerable<TSource> Repeat<TSource>(this IEnumerable<TSource> source)
```

コードは[こちら](https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L638)


## 単純な呼び出し例

### その1を呼び出す

```csharp
IEnumerable<string> enumerable = EnumerableEx.Repeat ("a");
```

### その2を呼び出す

```csharp
IEnumerable<string> strings = new []{"b", "b", "c"};
IEnumerable<string> enumerable = EnumerableEx.Repeat(strings);
```

## その1とその2、どちらの呼ばれるのか

### その1が呼ばれる

```csharp
IEnumerable<string> strings = new []{ "a", "b", "c" };
IEnumerable <IEnumerable<int>> enumerable = EnumerableEx.Repeat (strings);
```

```csharp
IEnumerable<string> strings = new []{ "a", "b", "c" };
var enumerable = EnumerableEx.Repeat<IEnumerable<int>> (strings);
```

```csharp
string[] strings = new []{ "a", "b", "c" };
var enumerable = EnumerableEx.Repeat (strings);
```

```csharp
string[] strings = new []{ "a", "b", "c" };
var enumerable = EnumerableEx.Repeat<string[]> (strings);
```

### その2が呼ばれる

```csharp
IEnumerable<string> strings = new []{ "a", "b", "c" };
var enumerable = EnumerableEx.Repeat (strings);
```

```csharp
string[] strings = new []{ "a", "b", "c" };
var enumerable = EnumerableEx.Repeat<string> (strings);
```

### コンパイルエラー

```csharp
string[] strings = new []{ "a", "b", "c" };
var enumerable = EnumerableEx.Repeat (strings);
```



