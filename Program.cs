using System;
using System.Collections.Generic;

// Iterator インターフェース
interface IIterator
{
    bool HasNext();
    object Next();
}

// 文字列のイテレータ
class StringIterator : IIterator
{
    private string _str;
    private int _index;

    public StringIterator(string str)
    {
        _str = str;
        _index = 0;
    }

    public bool HasNext()
    {
        return _index < _str.Length;
    }

    public object Next()
    {
        char character = _str[_index];
        _index++;
        return character;
    }
}

// コマンドクラス
class IteCommand
{
    private IIterator _iterator;

    public IteCommand(string str)
    {
        _iterator = new StringIterator(str);
    }

    public void Execute()
    {
        while (_iterator.HasNext())
        {
            var character = _iterator.Next();
            Console.Write(character);
        }
    }
}

// メインプログラム
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("文字列を入力してください（入力終了はCtrl+Z）:");
        List<string> lines = new List<string>();
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            lines.Add(line);
        }

        string inputString = string.Join(Environment.NewLine, lines);
        var command = new IteCommand(inputString);
        command.Execute();
    }
}
