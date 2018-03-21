/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     21/03/2018 21:14:18                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Desa') and o.name = 'FK_DESA_TERDIRI_D_KECAMATA')
alter table Desa
   drop constraint FK_DESA_TERDIRI_D_KECAMATA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DosenPembimbing') and o.name = 'FK_DOSENPEM_DIBIMBING_KELOMPOK')
alter table DosenPembimbing
   drop constraint FK_DOSENPEM_DIBIMBING_KELOMPOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DosenPembimbing') and o.name = 'FK_DOSENPEM_MILIK_DOS_AKUN')
alter table DosenPembimbing
   drop constraint FK_DOSENPEM_MILIK_DOS_AKUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Indikator') and o.name = 'FK_INDIKATO_DITULIS_O_AKUN')
alter table Indikator
   drop constraint FK_INDIKATO_DITULIS_O_AKUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Indikator') and o.name = 'FK_INDIKATO_MEMILIKI__DESA')
alter table Indikator
   drop constraint FK_INDIKATO_MEMILIKI__DESA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Kabupaten') and o.name = 'FK_KABUPATE_TERDIRI_D_PROVINSI')
alter table Kabupaten
   drop constraint FK_KABUPATE_TERDIRI_D_PROVINSI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Kecamatan') and o.name = 'FK_KECAMATA_TERDIRI_D_KABUPATE')
alter table Kecamatan
   drop constraint FK_KECAMATA_TERDIRI_D_KABUPATE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('KelompokKkn') and o.name = 'FK_KELOMPOK_DIBINA_OL_DESA')
alter table KelompokKkn
   drop constraint FK_KELOMPOK_DIBINA_OL_DESA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('KelompokKkn') and o.name = 'FK_KELOMPOK_MENGUTUS_UNIVERSI')
alter table KelompokKkn
   drop constraint FK_KELOMPOK_MENGUTUS_UNIVERSI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Komentar') and o.name = 'FK_KOMENTAR_KNOWLEDGE_PENILAIA')
alter table Komentar
   drop constraint FK_KOMENTAR_KNOWLEDGE_PENILAIA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Mahasiswa') and o.name = 'FK_MAHASISW_MILIK_MHS_AKUN')
alter table Mahasiswa
   drop constraint FK_MAHASISW_MILIK_MHS_AKUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Mahasiswa') and o.name = 'FK_MAHASISW_OLEH_KELOMPOK')
alter table Mahasiswa
   drop constraint FK_MAHASISW_OLEH_KELOMPOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Pemda') and o.name = 'FK_PEMDA_BEKERJA_DESA')
alter table Pemda
   drop constraint FK_PEMDA_BEKERJA_DESA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Pemda') and o.name = 'FK_PEMDA_MILIK_PEM_AKUN')
alter table Pemda
   drop constraint FK_PEMDA_MILIK_PEM_AKUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Penilaian') and o.name = 'FK_PENILAIA_BERDASARK_INDIKATO')
alter table Penilaian
   drop constraint FK_PENILAIA_BERDASARK_INDIKATO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Penilaian') and o.name = 'FK_PENILAIA_DINILAI_PROGRAM')
alter table Penilaian
   drop constraint FK_PENILAIA_DINILAI_PROGRAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Penilaian') and o.name = 'FK_PENILAIA_DINILAI_O_AKUN')
alter table Penilaian
   drop constraint FK_PENILAIA_DINILAI_O_AKUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Program') and o.name = 'FK_PROGRAM_MELAKSANA_KELOMPOK')
alter table Program
   drop constraint FK_PROGRAM_MELAKSANA_KELOMPOK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Akun')
            and   type = 'U')
   drop table Akun
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Desa')
            and   type = 'U')
   drop table Desa
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DosenPembimbing')
            and   type = 'U')
   drop table DosenPembimbing
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Indikator')
            and   type = 'U')
   drop table Indikator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Kabupaten')
            and   type = 'U')
   drop table Kabupaten
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Kecamatan')
            and   type = 'U')
   drop table Kecamatan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KelompokKkn')
            and   type = 'U')
   drop table KelompokKkn
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Komentar')
            and   type = 'U')
   drop table Komentar
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Mahasiswa')
            and   type = 'U')
   drop table Mahasiswa
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Pemda')
            and   type = 'U')
   drop table Pemda
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Penilaian')
            and   type = 'U')
   drop table Penilaian
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Program')
            and   type = 'U')
   drop table Program
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Provinsi')
            and   type = 'U')
   drop table Provinsi
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Universitas')
            and   type = 'U')
   drop table Universitas
go

/*==============================================================*/
/* Table: Akun                                                  */
/*==============================================================*/
create table Akun (
   Username             varchar(25)          not null,
   Email                varchar(254)         null,
   Password             varchar(60)          null,
   constraint PK_AKUN primary key nonclustered (Username)
)
go

/*==============================================================*/
/* Table: Desa                                                  */
/*==============================================================*/
create table Desa (
   KodeDesa             varchar(10)          not null,
   KodeKec              char(7)              null,
   NamaDesa             varchar(34)          null,
   KearifanLokal        text                 null,
   constraint PK_DESA primary key nonclustered (KodeDesa)
)
go

/*==============================================================*/
/* Table: DosenPembimbing                                       */
/*==============================================================*/
create table DosenPembimbing (
   Username             varchar(25)          not null,
   NIDN                 varchar(10)          not null,
   IdKel                int                  null,
   Nama                 varchar(34)          null,
   constraint PK_DOSENPEMBIMBING primary key nonclustered (Username, NIDN)
)
go

/*==============================================================*/
/* Table: Indikator                                             */
/*==============================================================*/
create table Indikator (
   KodeDesa             varchar(10)          not null,
   IdIndikator          int                  not null identity(1,1),
   Username             varchar(25)          null,
   Judul                varchar(35)          null,
   Deskripsi            text                 null,
   Konfirmasi           bit                  null,
   constraint PK_INDIKATOR primary key nonclustered (KodeDesa, IdIndikator)
)
go

/*==============================================================*/
/* Table: Kabupaten                                             */
/*==============================================================*/
create table Kabupaten (
   KodeKab              char(4)              not null,
   KodeProv             char(2)              null,
   NamaKab              varchar(34)          null,
   constraint PK_KABUPATEN primary key nonclustered (KodeKab)
)
go

/*==============================================================*/
/* Table: Kecamatan                                             */
/*==============================================================*/
create table Kecamatan (
   KodeKec              char(7)              not null,
   KodeKab              char(4)              null,
   NamaKec              varchar(34)          null,
   constraint PK_KECAMATAN primary key nonclustered (KodeKec)
)
go

/*==============================================================*/
/* Table: KelompokKkn                                           */
/*==============================================================*/
create table KelompokKkn (
   IdKel                int                  not null identity(1,1),
   KodeDesa             varchar(10)          null,
   IdUniv               int                  null,
   NamaKel              varchar(30)          null,
   TanggalMulai         datetime             null,
   TanggalAkhir         datetime             null,
   NIMKetua             varchar(10)          null,
   constraint PK_KELOMPOKKKN primary key nonclustered (IdKel)
)
go

/*==============================================================*/
/* Table: Komentar                                              */
/*==============================================================*/
create table Komentar (
   IdPenilaian          int                  not null,
   IdKomentar           int                  not null identity(1,1),
   DescKomentar         text                 null,
   constraint PK_KOMENTAR primary key nonclustered (IdPenilaian, IdKomentar)
)
go

/*==============================================================*/
/* Table: Mahasiswa                                             */
/*==============================================================*/
create table Mahasiswa (
   Username             varchar(25)          not null,
   NIM                  varchar(10)          not null,
   IdKel                int                  null,
   Nama                 varchar(34)          null,
   Jurusan              varchar(19)          null,
   Prodi                varchar(19)          null,
   constraint PK_MAHASISWA primary key nonclustered (Username, NIM)
)
go

/*==============================================================*/
/* Table: Pemda                                                 */
/*==============================================================*/
create table Pemda (
   Username             varchar(25)          not null,
   NIP                  varchar(20)          not null,
   KodeDesa             varchar(10)          null,
   NamaLengkap          varchar(35)          null,
   constraint PK_PEMDA primary key nonclustered (Username, NIP)
)
go

/*==============================================================*/
/* Table: Penilaian                                             */
/*==============================================================*/
create table Penilaian (
   IdPenilaian          int                  not null identity(1,1),
   Username             varchar(25)          null,
   KodeDesa             varchar(10)          not null,
   IdIndikator          int                  not null,
   IdKel                int                  not null,
   Id                   int                  not null,
   Alasan               text                 null,
   Skor                 int                  null,
   constraint PK_PENILAIAN primary key nonclustered (IdPenilaian)
)
go

/*==============================================================*/
/* Table: Program                                               */
/*==============================================================*/
create table Program (
   IdKel                int                  not null,
   Id                   int                  not null identity(1,1),
   NamaProgram          varchar(35)          null,
   Deskripsi            text                 null,
   Realisasi            bit                  null,
   constraint PK_PROGRAM primary key nonclustered (IdKel, Id)
)
go

/*==============================================================*/
/* Table: Provinsi                                              */
/*==============================================================*/
create table Provinsi (
   KodeProv             char(2)              not null,
   NamaProv             varchar(34)          null,
   constraint PK_PROVINSI primary key nonclustered (KodeProv)
)
go

/*==============================================================*/
/* Table: Universitas                                           */
/*==============================================================*/
create table Universitas (
   IdUniv               int                  not null identity(1,1),
   NamaUniv             varchar(34)          null,
   constraint PK_UNIVERSITAS primary key nonclustered (IdUniv)
)
go

alter table Desa
   add constraint FK_DESA_TERDIRI_D_KECAMATA foreign key (KodeKec)
      references Kecamatan (KodeKec)
go

alter table DosenPembimbing
   add constraint FK_DOSENPEM_DIBIMBING_KELOMPOK foreign key (IdKel)
      references KelompokKkn (IdKel)
go

alter table DosenPembimbing
   add constraint FK_DOSENPEM_MILIK_DOS_AKUN foreign key (Username)
      references Akun (Username)
go

alter table Indikator
   add constraint FK_INDIKATO_DITULIS_O_AKUN foreign key (Username)
      references Akun (Username)
go

alter table Indikator
   add constraint FK_INDIKATO_MEMILIKI__DESA foreign key (KodeDesa)
      references Desa (KodeDesa)
go

alter table Kabupaten
   add constraint FK_KABUPATE_TERDIRI_D_PROVINSI foreign key (KodeProv)
      references Provinsi (KodeProv)
go

alter table Kecamatan
   add constraint FK_KECAMATA_TERDIRI_D_KABUPATE foreign key (KodeKab)
      references Kabupaten (KodeKab)
go

alter table KelompokKkn
   add constraint FK_KELOMPOK_DIBINA_OL_DESA foreign key (KodeDesa)
      references Desa (KodeDesa)
go

alter table KelompokKkn
   add constraint FK_KELOMPOK_MENGUTUS_UNIVERSI foreign key (IdUniv)
      references Universitas (IdUniv)
go

alter table Komentar
   add constraint FK_KOMENTAR_KNOWLEDGE_PENILAIA foreign key (IdPenilaian)
      references Penilaian (IdPenilaian)
go

alter table Mahasiswa
   add constraint FK_MAHASISW_MILIK_MHS_AKUN foreign key (Username)
      references Akun (Username)
go

alter table Mahasiswa
   add constraint FK_MAHASISW_OLEH_KELOMPOK foreign key (IdKel)
      references KelompokKkn (IdKel)
go

alter table Pemda
   add constraint FK_PEMDA_BEKERJA_DESA foreign key (KodeDesa)
      references Desa (KodeDesa)
go

alter table Pemda
   add constraint FK_PEMDA_MILIK_PEM_AKUN foreign key (Username)
      references Akun (Username)
go

alter table Penilaian
   add constraint FK_PENILAIA_BERDASARK_INDIKATO foreign key (KodeDesa, IdIndikator)
      references Indikator (KodeDesa, IdIndikator)
go

alter table Penilaian
   add constraint FK_PENILAIA_DINILAI_PROGRAM foreign key (IdKel, Id)
      references Program (IdKel, Id)
go

alter table Penilaian
   add constraint FK_PENILAIA_DINILAI_O_AKUN foreign key (Username)
      references Akun (Username)
go

alter table Program
   add constraint FK_PROGRAM_MELAKSANA_KELOMPOK foreign key (IdKel)
      references KelompokKkn (IdKel)
go

