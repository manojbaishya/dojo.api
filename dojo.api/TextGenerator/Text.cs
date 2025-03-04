using RimuTec.Faker;

namespace Dojo.Api.TextGenerator;

public readonly struct Text(int NumberOfParagraphs)
{
    public readonly ReadOnlyMemory<string> Paragraphs { get; } = Lorem.Paragraphs(NumberOfParagraphs).ToArray();
}