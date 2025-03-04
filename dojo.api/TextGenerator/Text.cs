using RimuTec.Faker;

namespace Dojo.Api.TextGenerator;

public readonly struct Text(int numberOfParagraphs)
{
    public ReadOnlyMemory<string> Paragraphs { get; } = Lorem.Paragraphs(numberOfParagraphs).ToArray();
}