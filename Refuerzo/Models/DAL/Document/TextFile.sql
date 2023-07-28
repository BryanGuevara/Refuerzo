CREATE DATABASE MiBaseDeDatos;
GO

USE MiBaseDeDatos;
GO

CREATE TABLE MiTabla (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50),
    Edad INT,
    CorreoElectronico NVARCHAR(100)
);
GO

INSERT INTO MiTabla (Nombre, Edad, CorreoElectronico)
VALUES ('Juan', 30, 'juan@example.com');

INSERT INTO MiTabla (Nombre, Edad, CorreoElectronico)
VALUES ('María', 25, 'maria@example.com');

INSERT INTO MiTabla (Nombre, Edad, CorreoElectronico)
VALUES ('Carlos', 40, 'carlos@example.com');
