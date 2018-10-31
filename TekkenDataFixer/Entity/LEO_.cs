namespace TekkenDataFixer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewTemp.LEO$")]
    public partial class LEO_
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Command { get; set; }

        [Column("Hit level")]
        [StringLength(255)]
        public string Hit_level { get; set; }

        [StringLength(255)]
        public string Damage { get; set; }

        [Column("Start up frame")]
        [StringLength(255)]
        public string Start_up_frame { get; set; }

        [Column("Block frame")]
        [StringLength(255)]
        public string Block_frame { get; set; }

        [Column("Hit frame")]
        [StringLength(255)]
        public string Hit_frame { get; set; }

        [Column("Counter hit frame")]
        [StringLength(255)]
        public string Counter_hit_frame { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }
    }
}
