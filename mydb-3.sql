-- phpMyAdmin SQL Dump
-- version 4.5.2
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 13-12-2016 a las 17:20:22
-- Versión del servidor: 10.1.19-MariaDB
-- Versión de PHP: 7.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `mydb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Aulas`
--

CREATE TABLE `Aulas` (
  `idAula` int(11) NOT NULL,
  `Materia` text NOT NULL,
  `HorarioInicial` int(11) NOT NULL,
  `HorarioFinal` int(11) NOT NULL,
  `Dias` varchar(45) NOT NULL,
  `Edificio` varchar(45) NOT NULL,
  `Profesor` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `Aulas`
--

INSERT INTO `Aulas` (`idAula`, `Materia`, `HorarioInicial`, `HorarioFinal`, `Dias`, `Edificio`, `Profesor`) VALUES
(109, 'INTELIGENCIA ARTIFICIAL I', 1300, 1500, 'L', 'HEDE', 'ALFARO CASTELLANOS, KLEOPHE'),
(109, 'SEMINARIO DE SOLUCION DE PROBLEMAS DE INTELIGENCIA ARTIFICAL', 900, 1100, 'L', 'HEDE', 'ALFARO CASTELLANOS, KLEOPHE'),
(109, 'INTELIGENCIA ARTIFICIAL II', 700, 855, 'L', 'HEDE', 'BECERRA GONZALEZ, HECTOR MANUEL');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Biblioteca`
--

CREATE TABLE `Biblioteca` (
  `NoSistema` int(11) NOT NULL,
  `ISBN` bigint(20) DEFAULT NULL,
  `Autor` text,
  `TituloUniforme` text COMMENT '		',
  `Titulo` text,
  `Edicion` text,
  `PieDeImprenta` text,
  `DescrFisica` text,
  `Nota` text,
  `TemaGeneral` text,
  `ASecPersonas` text,
  `BaseLogica` text
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `Biblioteca`
--

INSERT INTO `Biblioteca` (`NoSistema`, `ISBN`, `Autor`, `TituloUniforme`, `Titulo`, `Edicion`, `PieDeImprenta`, `DescrFisica`, `Nota`, `TemaGeneral`, `ASecPersonas`, `BaseLogica`) VALUES
(434084, 9786073126977, 'King, Stephen, 1947-, autor.', '[Mr. Mercedes. Español]', 'Mr. Mercedes / Stephen King; traducción de Carlos Milla Soler.', 'Primera edición en México', 'Mexico, D.F. Random House Grupo Editorial, S.A. de C.V. 2014 primera reimpresión 2015.', '491 páginas ; 23 cm.', 'Traducción de: Mr. Mercedes.', 'Novela estadounidense - Siglo XX.\r\nLiteratura estadounidense - Siglo XX.', 'Milla Soler, Carlos, traductor.', 'Libros'),
(412454, 9786074005523, 'Alighieri, Dante', 'La divina comedia', 'La divina comedia / Dante Alighieri', NULL, 'España : Oceano, 2013.', NULL, NULL, NULL, NULL, NULL),
(349780, 9780470563120, 'Curioso, Andrew.', 'Expert PHP and MySQL', 'Expert PHP and MySQL / Andrew Curioso, Ronald Bradford, Patrick Galbraith.', NULL, 'Indianapolis, IN : Wiley Pub., c2010.', 'xxxiii, 587 p. : il. ; 24 cm.', 'Encubierta: "Wrox programador a programador".', 'Cliente/servidor (Computación).\r\nPHP (Lenguaje de programación).\r\nMySQL (Lenguajede programación de bases de datos).', 'Bradford, Ronald, aut.\r\nGalbraith, Patrick, aut.', 'Libros'),
(418708, 9788441535688, 'Cabezas Granado, Luis Miguel, autor.', 'Desarrollo web con PHP Y MySQL', 'Desarrollo web con PHP Y MySQL / Luis Miguel Cabezas Granado', NULL, 'Madrid : Ediciones Anaya Multimedia, 2014.', '287 páginas : diagramas. ; 20 cm.', 'Incluye tabla de contenido e índice.', NULL, 'González Lozano, Francisco José, autor.', 'Libros');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `Biblioteca`
--
ALTER TABLE `Biblioteca`
  ADD PRIMARY KEY (`NoSistema`),
  ADD UNIQUE KEY `NoSistema_UNIQUE` (`NoSistema`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
