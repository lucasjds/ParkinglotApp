using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkinglotApp.Model.Base
{
  public class EntidadeBase
  {
    [Key, Column("codigo")]
    public long Codigo { get; set; }
  }
}
