using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.Text;

namespace System.CommandLine.SourceGenerator;

internal sealed class SourceTextBuilder
{
    private int _depth;

    private readonly StringBuilder _buffer = new();

    public SourceTextBuilder Indent(int offset = 0)
    {
        _buffer.Append(' ', (_depth + offset) * 4);
        return this;
    }

    public SourceTextBuilder Write(string value, bool indent = false)
    {
        if (indent)
            Indent();

        _buffer.Append(value);
        return this;
    }

    public SourceTextBuilder WriteJoin(string separator, IEnumerable<string> values, bool indent = false)
    {
        return Write(string.Join(separator, values), indent);
    }

    public SourceTextBuilder WriteLine(bool indent = false)
    {
        if (indent)
            Indent();

        _buffer.AppendLine();
        return this;
    }

    public SourceTextBuilder WriteLine(string value, bool indent = false)
    {
        if (indent)
            Indent();

        _buffer.AppendLine(value);
        return this;
    }

    public SourceTextBuilder WriteBlock(string value, bool indent = false)
    {
        if (!indent)
            return WriteLine(value);

        var lines = Regex.Split(value, "\r\n|\r|\n");

        for (int i = 0; i < lines.Length; i++)
        {
            if (i > 0)
                _buffer.AppendLine();

            Indent().Write(lines[i]);
        }

        return this;
    }

    public SourceTextBuilder WriteLineJoin(string separator, IEnumerable<string> values, bool indent = false)
    {
        return WriteLine(string.Join(separator, values), indent);
    }

    public SourceTextBuilder OpenBrace(bool newLine = true)
    {
        Indent();

        if (newLine)
            _buffer.AppendLine("{");
        else
            _buffer.Append('{');

        _depth++;
        return this;
    }

    public SourceTextBuilder CloseBrace(bool newLine = true)
    {
        _depth--;
        Indent();

        if (newLine)
            _buffer.AppendLine("}");
        else
            _buffer.Append('}');

        return this;
    }

    public SourceText Build()
    {
        return SourceText.From(_buffer.ToString(), Encoding.UTF8);
    }
}
