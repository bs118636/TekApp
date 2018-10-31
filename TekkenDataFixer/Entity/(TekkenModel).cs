namespace TekkenDataFixer.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TekkenModel : DbContext
    {
        public TekkenModel()
            : base("name=TekkenModel1")
        {
        }

        public virtual DbSet<AKUMA_> AKUMA_ { get; set; }
        public virtual DbSet<ALISA_> ALISA_ { get; set; }
        public virtual DbSet<ASUKA_> ASUKA_ { get; set; }
        public virtual DbSet<BOB_> BOB_ { get; set; }
        public virtual DbSet<BRYAN_> BRYAN_ { get; set; }
        public virtual DbSet<CLAUDIO_> CLAUDIO_ { get; set; }
        public virtual DbSet<DEVIL_JIN_> DEVIL_JIN_ { get; set; }
        public virtual DbSet<DRAGUNOV_> DRAGUNOV_ { get; set; }
        public virtual DbSet<EDDY_> EDDY_ { get; set; }
        public virtual DbSet<ELIZA_> ELIZA_ { get; set; }
        public virtual DbSet<FENG_> FENG_ { get; set; }
        public virtual DbSet<GEESE_> GEESE_ { get; set; }
        public virtual DbSet<GIGAS_> GIGAS_ { get; set; }
        public virtual DbSet<HEIHACHI_> HEIHACHI_ { get; set; }
        public virtual DbSet<HWOARANG_> HWOARANG_ { get; set; }
        public virtual DbSet<JACK7_> JACK7_ { get; set; }
        public virtual DbSet<JIN_> JIN_ { get; set; }
        public virtual DbSet<JOSIE_> JOSIE_ { get; set; }
        public virtual DbSet<KATARINA_> KATARINA_ { get; set; }
        public virtual DbSet<KAZUMI_> KAZUMI_ { get; set; }
        public virtual DbSet<KAZUYA_> KAZUYA_ { get; set; }
        public virtual DbSet<KING_> KING_ { get; set; }
        public virtual DbSet<KUMA_> KUMA_ { get; set; }
        public virtual DbSet<LARS_> LARS_ { get; set; }
        public virtual DbSet<LAW_> LAW_ { get; set; }
        public virtual DbSet<LEE_> LEE_ { get; set; }
        public virtual DbSet<LEO_> LEO_ { get; set; }
        public virtual DbSet<LILI_> LILI_ { get; set; }
        public virtual DbSet<LUCKY_CHLOE_> LUCKY_CHLOE_ { get; set; }
        public virtual DbSet<MASTER_RAVEN_> MASTER_RAVEN_ { get; set; }
        public virtual DbSet<MIGUEL_> MIGUEL_ { get; set; }
        public virtual DbSet<NINA_> NINA_ { get; set; }
        public virtual DbSet<NOCTIS_> NOCTIS_ { get; set; }
        public virtual DbSet<PAUL_> PAUL_ { get; set; }
        public virtual DbSet<SHAHEEN_> SHAHEEN_ { get; set; }
        public virtual DbSet<STEVE_> STEVE_ { get; set; }
        public virtual DbSet<XIAOYU_> XIAOYU_ { get; set; }
        public virtual DbSet<YOSHIMITSU_> YOSHIMITSU_ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
