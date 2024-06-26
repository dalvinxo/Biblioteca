﻿// <auto-generated />
using System;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.Migrations
{
    [DbContext(typeof(SqlDatabaseBibliotecaContext))]
    [Migration("20240610015110_newTableUsuarioEmpleado")]
    partial class newTableUsuarioEmpleado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Biblioteca.Models.Autore", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<string>("IdiomaNativo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PaisOrigen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Identificador")
                        .HasName("PK__Autores__F2374EB187A61A20");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Biblioteca.Models.Ciencia", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.HasKey("Identificador")
                        .HasName("PK__Ciencias__F2374EB127E7D75D");

                    b.ToTable("Ciencias");
                });

            modelBuilder.Entity("Biblioteca.Models.Editora", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.HasKey("Identificador")
                        .HasName("PK__Editoras__F2374EB170C37B1E");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("Biblioteca.Models.Empleado", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateOnly?>("FechaIngreso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PorcientoComision")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("TandaLabor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Identificador")
                        .HasName("PK__Empleado__F2374EB1C058497D");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Biblioteca.Models.Idioma", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.HasKey("Identificador")
                        .HasName("PK__Idiomas__F2374EB1BFCBD7E5");

                    b.ToTable("Idiomas");
                });

            modelBuilder.Entity("Biblioteca.Models.Libro", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnioPublicacion")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Autores")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Ciencia")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Editora")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<int?>("Idioma")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("ISBN");

                    b.Property<string>("SignaturaTopografica")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("TipoBibliografia")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Identificador")
                        .HasName("PK__Libros__F2374EB1201BE782");

                    b.HasIndex("Autores");

                    b.HasIndex("Ciencia");

                    b.HasIndex("Editora");

                    b.HasIndex("Idioma");

                    b.HasIndex("TipoBibliografia");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Biblioteca.Models.PrestamoDevolucion", b =>
                {
                    b.Property<int>("NoPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CantidadDias")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentario")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Empleado")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateOnly?>("FechaDevolucion")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("FechaPrestamo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Libro")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("MontoXdia")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("MontoXDia");

                    b.Property<int?>("Usuario")
                        .HasColumnType("INTEGER");

                    b.HasKey("NoPrestamo")
                        .HasName("PK__Prestamo__E21CCFF3472922B1");

                    b.HasIndex("Empleado");

                    b.HasIndex("Libro");

                    b.HasIndex("Usuario");

                    b.ToTable("PrestamoDevolucion");
                });

            modelBuilder.Entity("Biblioteca.Models.TiposBibliografium", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.HasKey("Identificador")
                        .HasName("PK__TiposBib__F2374EB192DD4C49");

                    b.ToTable("TiposBibliografia");
                });

            modelBuilder.Entity("Biblioteca.Models.Usuario", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<string>("NoCarnet")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPersona")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Identificador")
                        .HasName("PK__Usuarios__F2374EB14AAEC3E4");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Biblioteca.Models.UsuariosEmpleado", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Empleado")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("FechaUltimoInicioSesion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("RestablecerPassword")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Identificador")
                        .HasName("PK__Empleado__F2374EB1C058497D");

                    b.HasIndex("Empleado");

                    b.ToTable("UsuariosEmpleado");
                });

            modelBuilder.Entity("Biblioteca.Models.Libro", b =>
                {
                    b.HasOne("Biblioteca.Models.Autore", "AutoresNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("Autores")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Libros__Autores__6754599E");

                    b.HasOne("Biblioteca.Models.Ciencia", "CienciaNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("Ciencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Libros__Ciencia__693CA210");

                    b.HasOne("Biblioteca.Models.Editora", "EditoraNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("Editora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Libros__Editora__68487DD7");

                    b.HasOne("Biblioteca.Models.Idioma", "IdiomaNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("Idioma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Libros__Idioma__6A30C649");

                    b.HasOne("Biblioteca.Models.TiposBibliografium", "TipoBibliografiaNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("TipoBibliografia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Libros__TipoBibl__66603565");

                    b.Navigation("AutoresNavigation");

                    b.Navigation("CienciaNavigation");

                    b.Navigation("EditoraNavigation");

                    b.Navigation("IdiomaNavigation");

                    b.Navigation("TipoBibliografiaNavigation");
                });

            modelBuilder.Entity("Biblioteca.Models.PrestamoDevolucion", b =>
                {
                    b.HasOne("Biblioteca.Models.Empleado", "EmpleadoNavigation")
                        .WithMany("PrestamoDevolucions")
                        .HasForeignKey("Empleado")
                        .HasConstraintName("FK__PrestamoD__Emple__70DDC3D8");

                    b.HasOne("Biblioteca.Models.Libro", "LibroNavigation")
                        .WithMany("PrestamoDevolucions")
                        .HasForeignKey("Libro")
                        .HasConstraintName("FK__PrestamoD__Libro__71D1E811");

                    b.HasOne("Biblioteca.Models.Usuario", "UsuarioNavigation")
                        .WithMany("PrestamoDevolucions")
                        .HasForeignKey("Usuario")
                        .HasConstraintName("FK__PrestamoD__Usuar__72C60C4A");

                    b.Navigation("EmpleadoNavigation");

                    b.Navigation("LibroNavigation");

                    b.Navigation("UsuarioNavigation");
                });

            modelBuilder.Entity("Biblioteca.Models.UsuariosEmpleado", b =>
                {
                    b.HasOne("Biblioteca.Models.Empleado", "EmpleadoNavigation")
                        .WithMany("UsuariosEmpleados")
                        .HasForeignKey("Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmpleadoNavigation");
                });

            modelBuilder.Entity("Biblioteca.Models.Autore", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Biblioteca.Models.Ciencia", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Biblioteca.Models.Editora", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Biblioteca.Models.Empleado", b =>
                {
                    b.Navigation("PrestamoDevolucions");

                    b.Navigation("UsuariosEmpleados");
                });

            modelBuilder.Entity("Biblioteca.Models.Idioma", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Biblioteca.Models.Libro", b =>
                {
                    b.Navigation("PrestamoDevolucions");
                });

            modelBuilder.Entity("Biblioteca.Models.TiposBibliografium", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Biblioteca.Models.Usuario", b =>
                {
                    b.Navigation("PrestamoDevolucions");
                });
#pragma warning restore 612, 618
        }
    }
}
