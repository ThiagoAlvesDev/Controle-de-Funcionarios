﻿// <auto-generated />
using System;
using ControleDeFuncionarios.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeFuncionarios.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20230523225953_teste")]
    partial class Teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("ControleDeFuncionarios.Models.CargoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CBO")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Funcao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CargoModel");
                });

            modelBuilder.Entity("ControleDeFuncionarios.Models.ColaboradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CargoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataDemissao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matricula")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeColaborador")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("ControleDeFuncionarios.Models.EmpresaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("TEXT");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EmpresaModel");
                });

            modelBuilder.Entity("ControleDeFuncionarios.Models.ColaboradorModel", b =>
                {
                    b.HasOne("ControleDeFuncionarios.Models.CargoModel", "Cargo")
                        .WithMany("Colaboradores")
                        .HasForeignKey("CargoId");

                    b.HasOne("ControleDeFuncionarios.Models.EmpresaModel", "Empresa")
                        .WithMany("Colaboradores")
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Cargo");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ControleDeFuncionarios.Models.CargoModel", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("ControleDeFuncionarios.Models.EmpresaModel", b =>
                {
                    b.Navigation("Colaboradores");
                });
#pragma warning restore 612, 618
        }
    }
}
