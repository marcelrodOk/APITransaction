using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TransactionService.Data.Model;

namespace TransactionService.Data;

public partial class TransactionDbContext : DbContext
{

    public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TransaccionesTc> TransaccionesTcs { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {


		builder.Entity<TransaccionesTc>(entity =>
        {
            entity.HasKey(e => new { e.CodEnte, e.NroUsuario, e.Aacc, e.FechaPago, e.CodAutorizacion, e.HoraPago }).HasFillFactor(80);

            entity.ToTable("TransaccionesTC");

            entity.HasIndex(e => new { e.FechaPago, e.HoraPago, e.FechaCierre }, "FEchaPAgoHoraPAgoFechaCierre").HasFillFactor(90);

            entity.HasIndex(e => new { e.FechaRend, e.TipoTarjeta }, "IDX_RendicionPagoTelefonico").HasFillFactor(80);

            entity.HasIndex(e => new { e.NroTarjeta, e.FechaPago }, "Indice para busqueda de cantidad de pagos realizados con tarjeta").HasFillFactor(90);

            entity.HasIndex(e => new { e.NroUsuario, e.Aacc }, "NrousuarioAACC").HasFillFactor(90);

            entity.HasIndex(e => new { e.CodEnte, e.NroUsuario, e.Aacc }, "codenteNroUsuarioAACC").HasFillFactor(90);

            entity.HasIndex(e => e.FechaHoraPublicacion, "idx_fechahorapub").HasFillFactor(90);

            entity.Property(e => e.CodEnte)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.NroUsuario)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Nro_Usuario");
            entity.Property(e => e.Aacc)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("AACC");
            entity.Property(e => e.FechaPago)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.CodAutorizacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HoraPago)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Hora_Pago");
            entity.Property(e => e.CodOblig)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Cod_Oblig");
            entity.Property(e => e.Comprobante).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.FechaCierre)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.FechaEnvioWeb)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraPublicacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaProceso)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Fecha_Proceso");
            entity.Property(e => e.FechaProrroga)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Fecha_Prorroga");
            entity.Property(e => e.FechaRend)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.FechaVto)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Fecha_Vto");
            entity.Property(e => e.Importe)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("importe");
            entity.Property(e => e.ImporteFact)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Importe_Fact");
            entity.Property(e => e.ImporteTotalAutorizado)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.IndicadorLifore)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NroTarjeta)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.NroTransaccion)
                .ValueGeneratedOnAdd()
                .HasColumnName("nro_Transaccion");
            entity.Property(e => e.RefNumber)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("Ref_number");
            entity.Property(e => e.Tipo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.TipoTarjeta)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("Tipo_Tarjeta");
        });

		base.OnModelCreating(builder);

		OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder builder);

	//protected override void OnModelCreating(ModelBuilder builder)
	//{
	//	base.OnModelCreating(builder);

	//	ModelConfig(builder);
	//}

}
