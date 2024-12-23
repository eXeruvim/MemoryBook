using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemoryBook.Models
{

    public class HeroesViewModel : MemBook
    {
    }

    [Table("mbook")]
    public class MemBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("dbid")]
        public int Id { get; set; }

        [Column("mid")]
        public string? Mid { get; set; }

        [Column("mentity")]
        public string? Entity { get; set; }

        [Column("mheader")]
        public string? Header { get; set; }

        [Column("mfamily")]
        public string? Family { get; set; }

        [Column("mname")]
        public string? Name { get; set; }

        [Column("mmiddlename")]
        public string? MiddleName { get; set; }

        [Column("mbirthday")]
        public string? Birthday { get; set; }

        [Column("mbirthplace")]
        public string? BirthPlace { get; set; }

        [Column("mdraftplace")]
        public string? DraftPlace { get; set; }

        [Column("mlastplace")]
        public string? LastPlace { get; set; }

        [Column("mrank")]
        public string? Rank { get; set; }

        [Column("mpost")]
        public string? Post { get; set; }

        [Column("mreasonout")]
        public string? ReasonOut { get; set; }

        [Column("mdatedeath")]
        public string? DateDeath { get; set; }

        [Column("mdateout")]
        public string? DateOut { get; set; }

        [Column("mplaceout")]
        public string? PlaceOut { get; set; }

        [Column("mgraveplace")]
        public string? GravePlace { get; set; }

        [Column("mfromgrave")]
        public string? FromGrave { get; set; }

        [Column("mhospital")]
        public string? Hospital { get; set; }

        [Column("mcamp")]
        public string? Camp { get; set; }

        [Column("mdatecamp")]
        public string? DateCamp { get; set; }

        [Column("mplacecamp")]
        public string? PlaceCamp { get; set; }

        [Column("mdestiny")]
        public string? Destiny { get; set; }

        [Column("mrelative")]
        public string? Relative { get; set; }

        [Column("maddinfo")]
        public string? AddInfo { get; set; }

        [Column("msource")]
        public string? Source { get; set; }

        [Column("verify")]
        public bool? Verify { get; set; }

        [Column("img")]
        public byte[]? Img { get; set; }

        [Column("heroes_order")]
        public bool? HeroesOrder { get; set; }

        [Column("heroes_soc")]
        public bool? HeroesSoc { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        [Column("pop_av")]
        public bool? PopAv { get; set; }

        [Column("pop_ak")]
        public bool? PopAk { get; set; }

        [Column("pop_zhp")]
        public bool? PopZhp { get; set; }

        [Column("pop_pr")]
        public bool? PopPr { get; set; }

        [Column("pop_sc")]
        public bool? PopSc { get; set; }

        [Column("pop_hs")]
        public bool? PopHs { get; set; }

        [Column("peoples_choices")]
        public bool? PeoplesChoices { get; set; }

        [Column("victory_parade_participants")]
        public bool? VictoryParadeParticipants { get; set; }
    }
}
