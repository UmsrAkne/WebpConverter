# Webp converter

## 概要

`.webp` の画像を `.png` に変換するためのソフトです。

## 要求環境

`.net Framework 4.7`  
`dwebp.exe`

## 使い方

### デコーダーをアプリのルートディレクトリに設置してアプリを起動

`dwebp.exe` は google の公式ページからダウンロードする。  
これは `libwebp` の一部に含まれているので、ダウンロードして中から取り出す。

また、`dwebp.exe` をアプリのルートディレクトリ以外に設置して使用したい場合は、画面上部のテキストボックスに絶対パスを記述する。  
デフォルトではこのテキストボックスにはアプリのルートのパスが入力される。

### アプリのウィンドウに webp ファイルをドラッグアンドドロップ  

`.webp` のドラッグアンドドロップは、同拡張子のファイルのみ有効。その他のファイルは UI に入力されない。

ドラッグアンドドロップの際、入力ファイルから出力ディレクトリのパスが自動で入力される。  

### convert ボタンを押下

変換後の出力を指定する場合は、上部のテキストボックスにディレクトリのパスを入力する。  
ここに入力されているパスが無効であった場合、変換後のファイルは変換前のファイルと同じディレクトリに出力される。

convert ボタンを押下後、全ファイルの変換終了まではボタンが無効となる。