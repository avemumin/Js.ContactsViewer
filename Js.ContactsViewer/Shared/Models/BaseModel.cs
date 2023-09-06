using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Js.ContactsViewer.Shared.Models;

/// <summary>
/// Klasa na wyrost jak na potrzeby tego projektu ale można się pobawić
/// na celu ma zmiejszenie powielania kodu oraz pewnych zachowań
/// raz zdefiniowany model bazowy z którego będziemy dziedziczyć
/// niweluje potrzebę powielania propercji dla np klucza gównego w tym wypadku
/// oraz dodaje atrybut CreateOn czyli momentu w którym tworzymy obiekt w bazie danych
/// </summary>
public class BaseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
