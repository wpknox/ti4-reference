using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public interface IPromissoryNoteRepository
{
    Task<PromissoryNote> GetPromissoryNote(string name, string? factionId = null);
}