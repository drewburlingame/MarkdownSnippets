﻿using MarkdownSnippets;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class SnippetExtensionsTests
{
    [Fact]
    public Task ToDictionary()
    {
        List<Snippet> snippets = new()
        {
            SnippetBuild("snippet1", "thePath"),
            SnippetBuild("snippet2", "thePath")
        };
        return Verifier.Verify(snippets.ToDictionary());
    }

    [Fact]
    public Task ToDictionary_SameKey()
    {
        List<Snippet> snippets = new()
        {
            SnippetBuild("snippet1", null),
            SnippetBuild("snippet1", "thePath2"),
            SnippetBuild("snippet1", "thePath1")
        };
        return Verifier.Verify(snippets.ToDictionary());
    }

    static Snippet SnippetBuild(string key, string? path)
    {
        return Snippet.Build(
            language: "language",
            startLine: 1,
            endLine: 2,
            value: "Snippet",
            key: key,
            path: path);
    }
}