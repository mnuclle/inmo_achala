-- -----------------------------------------------------
-- Schema achala_inmo_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `achala_inmo_db` DEFAULT CHARACTER SET utf8 ;
USE `achala_inmo_db` ;

-- -----------------------------------------------------
-- Table `achala_inmo_db`.`TIPOS_PROPIEDAD`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`TIPOS_PROPIEDAD` (
  `ID_TIPO_PROPIEDAD` INT NOT NULL,
  `N_TIPO_PROPIEDAD` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ID_TIPO_PROPIEDAD`),
  UNIQUE INDEX `N_TIPO_PROPIEDAD_UNIQUE` (`N_TIPO_PROPIEDAD` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`TIPOS_OPERACION`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`TIPOS_OPERACION` (
  `ID_TIPO_OPERACION` INT NOT NULL,
  `N_TIPO_OPERACION` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ID_TIPO_OPERACION`),
  UNIQUE INDEX `N_TIPO_OPERACION_UNIQUE` (`N_TIPO_OPERACION` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`AMBIENTES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`AMBIENTES` (
  `ID_AMBIENTE` INT NOT NULL,
  `N_AMBIENTE` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ID_AMBIENTE`),
  UNIQUE INDEX `N_AMBIENTE_UNIQUE` (`N_AMBIENTE` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`PROVINCIAS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`PROVINCIAS` (
  `ID_PROVINCIA` INT NOT NULL,
  `N_PROVINCIA` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ID_PROVINCIA`),
  UNIQUE INDEX `N_PROVINCIA_UNIQUE` (`N_PROVINCIA` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`DEPARTAMENTOS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`DEPARTAMENTOS` (
  `ID_DEPARTAMENTO` INT NOT NULL,
  `N_DEPARTAMENTO` VARCHAR(200) NOT NULL,
  `ID_PROVINCIA` INT NOT NULL,
  PRIMARY KEY (`ID_DEPARTAMENTO`),
  INDEX `fk_DEPARTAMENTOS_PROVINCIAS_idx` (`ID_PROVINCIA` ASC),
  CONSTRAINT `fk_DEPARTAMENTOS_PROVINCIAS`
    FOREIGN KEY (`ID_PROVINCIA`)
    REFERENCES `achala_inmo_db`.`PROVINCIAS` (`ID_PROVINCIA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`LOCALIDADES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`LOCALIDADES` (
  `ID_LOCALIDAD` INT NOT NULL,
  `N_LOCALIDAD` VARCHAR(200) NOT NULL,
  `ID_DEPARTAMENTO` INT NOT NULL,
  PRIMARY KEY (`ID_LOCALIDAD`),
  INDEX `fk_LOCALIDADES_DEPARTAMENTOS1_idx` (`ID_DEPARTAMENTO` ASC),
  CONSTRAINT `fk_LOCALIDADES_DEPARTAMENTOS1`
    FOREIGN KEY (`ID_DEPARTAMENTO`)
    REFERENCES `achala_inmo_db`.`DEPARTAMENTOS` (`ID_DEPARTAMENTO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`BARRIOS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`BARRIOS` (
  `ID_BARRIO` INT NOT NULL,
  `N_BARRIO` VARCHAR(200) NOT NULL,
  `ID_LOCALIDAD` INT NOT NULL,
  PRIMARY KEY (`ID_BARRIO`),
  INDEX `fk_BARRIOS_LOCALIDADES1_idx` (`ID_LOCALIDAD` ASC),
  CONSTRAINT `fk_BARRIOS_LOCALIDADES1`
    FOREIGN KEY (`ID_LOCALIDAD`)
    REFERENCES `achala_inmo_db`.`LOCALIDADES` (`ID_LOCALIDAD`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`DORMITORIOS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`DORMITORIOS` (
  `ID_DORMITORIO` INT NOT NULL,
  `N_DORMITORIO` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ID_DORMITORIO`),
  UNIQUE INDEX `N_DORMITORIO_UNIQUE` (`N_DORMITORIO` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`TIPOS_BARRIO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`TIPOS_BARRIO` (
  `ID_TIPO_BARRIO` INT NOT NULL,
  `N_TIPO_BARRIO` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`ID_TIPO_BARRIO`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`DOMICILIOS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`DOMICILIOS` (
  `ID_DOMICILIO` INT NOT NULL AUTO_INCREMENT,
  `CALLE` VARCHAR(200) NULL,
  `ALTURA` INT NULL,
  `PISO` INT NULL,
  `DEPARTAMENTO` VARCHAR(100) NULL,
  `TORRE` VARCHAR(100) NULL,
  `MANZANA` VARCHAR(100) NULL,
  `LOTE` VARCHAR(100) NULL,
  `ID_BARRIO` INT NULL,
  `ID_LOCALIDAD` INT NULL,
  `LATITUD` VARCHAR(45) NULL,
  `LONGITUD` VARCHAR(45) NULL,
  `ID_TIPO_BARRIO` INT NOT NULL,
  PRIMARY KEY (`ID_DOMICILIO`),
  INDEX `fk_DOMICILIOS_BARRIOS1_idx` (`ID_BARRIO` ASC),
  INDEX `fk_DOMICILIOS_LOCALIDADES1_idx` (`ID_LOCALIDAD` ASC),
  INDEX `fk_DOMICILIOS_T_TIPOS_BARRIO1_idx` (`ID_TIPO_BARRIO` ASC),
  CONSTRAINT `fk_DOMICILIOS_BARRIOS1`
    FOREIGN KEY (`ID_BARRIO`)
    REFERENCES `achala_inmo_db`.`BARRIOS` (`ID_BARRIO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DOMICILIOS_LOCALIDADES1`
    FOREIGN KEY (`ID_LOCALIDAD`)
    REFERENCES `achala_inmo_db`.`LOCALIDADES` (`ID_LOCALIDAD`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DOMICILIOS_T_TIPOS_BARRIO1`
    FOREIGN KEY (`ID_TIPO_BARRIO`)
    REFERENCES `achala_inmo_db`.`TIPOS_BARRIO` (`ID_TIPO_BARRIO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`ESTADOS_INMUEBLE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`ESTADOS_INMUEBLE` (
  `ID_ESTADO_INMUEBLE` INT NOT NULL,
  `N_ESTADO_INMUEBLE` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`ID_ESTADO_INMUEBLE`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`UBICACIONES_DEPARTAMENTO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`UBICACIONES_DEPARTAMENTO` (
  `ID_UBICACION_DEPARTAMENTO` INT NOT NULL,
  `N_UBICACION_DEPARTAMENTO` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`ID_UBICACION_DEPARTAMENTO`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`TIPOS_EMPRENDIMIENTO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`TIPOS_EMPRENDIMIENTO` (
  `ID_TIPO_EMPRENDIMIENTO` INT NOT NULL,
  `N_TIPO_EMPRENDIMIENTO` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`ID_TIPO_EMPRENDIMIENTO`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`INMUEBLES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`INMUEBLES` (
  `ID_INMUEBLE` INT NOT NULL AUTO_INCREMENT,
  `N_INMUEBLE` VARCHAR(200) NOT NULL,
  `DESCRIPCION` VARCHAR(1000) NULL,
  `SUPERFICIE_CUBIERTA` INT NULL,
  `SUPERFICIE_TERRENO` INT NULL,
  `SUPERFICIE_TOTAL` INT NULL,
  `CANTIDAD_BANIOS` INT NOT NULL,
  `CANTIDAD_AMBIENTES` INT NOT NULL,
  `CANTIDAD_DORMITORIOS` INT NOT NULL,
  `ANTIGUEDAD` INT NULL,
  `ID_DOMICILIO` INT NOT NULL,
  `ID_TIPO_PROPIEDAD` INT NOT NULL,
  `ID_ESTADO_INMUEBLE` INT NOT NULL,
  `FEC_BAJA` DATETIME NULL,
  `FEC_ALTA` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `FEC_MODIF` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ID_UBICACION_DEPARTAMENTO` INT NULL,
  `A_ESTRENAR` VARCHAR(1) NOT NULL DEFAULT 'N',
  `ID_TIPO_EMPRENDIMIENTO` INT NULL,
  PRIMARY KEY (`ID_INMUEBLE`),
  INDEX `fk_INMUEBLE_DOMICILIOS1_idx` (`ID_DOMICILIO` ASC),
  INDEX `fk_INMUEBLE_TIPOS_PROPIEDAD1_idx` (`ID_TIPO_PROPIEDAD` ASC),
  INDEX `fk_INMUEBLES_ESTADOS_INMUEBLE1_idx` (`ID_ESTADO_INMUEBLE` ASC),
  INDEX `fk_INMUEBLES_UBICACIONES_DEPARTAMENTO1_idx` (`ID_UBICACION_DEPARTAMENTO` ASC),
  INDEX `fk_INMUEBLES_TIPOS_EMPRENDIMIENTO1_idx` (`ID_TIPO_EMPRENDIMIENTO` ASC),
  CONSTRAINT `fk_INMUEBLE_DOMICILIOS1`
    FOREIGN KEY (`ID_DOMICILIO`)
    REFERENCES `achala_inmo_db`.`DOMICILIOS` (`ID_DOMICILIO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_INMUEBLE_TIPOS_PROPIEDAD1`
    FOREIGN KEY (`ID_TIPO_PROPIEDAD`)
    REFERENCES `achala_inmo_db`.`TIPOS_PROPIEDAD` (`ID_TIPO_PROPIEDAD`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_INMUEBLES_ESTADOS_INMUEBLE1`
    FOREIGN KEY (`ID_ESTADO_INMUEBLE`)
    REFERENCES `achala_inmo_db`.`ESTADOS_INMUEBLE` (`ID_ESTADO_INMUEBLE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_INMUEBLES_UBICACIONES_DEPARTAMENTO1`
    FOREIGN KEY (`ID_UBICACION_DEPARTAMENTO`)
    REFERENCES `achala_inmo_db`.`UBICACIONES_DEPARTAMENTO` (`ID_UBICACION_DEPARTAMENTO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_INMUEBLES_TIPOS_EMPRENDIMIENTO1`
    FOREIGN KEY (`ID_TIPO_EMPRENDIMIENTO`)
    REFERENCES `achala_inmo_db`.`TIPOS_EMPRENDIMIENTO` (`ID_TIPO_EMPRENDIMIENTO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`CARACTERISTICAS_INMUEBLE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`CARACTERISTICAS_INMUEBLE` (
  `ID_CARACTERISTICA_INMUEBLE` INT NOT NULL,
  `N_CARACTERISTICA_INMUEBLE` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ID_CARACTERISTICA_INMUEBLE`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`CARACTERISTICAS_X_INMUEBLE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`CARACTERISTICAS_X_INMUEBLE` (
  `ID_CARACTERISTICA_X_INMUEBLE` INT NOT NULL,
  `ID_INMUEBLE` INT NOT NULL,
  `ID_CARACTERISTICA_INMUEBLE` INT NOT NULL,
  PRIMARY KEY (`ID_CARACTERISTICA_X_INMUEBLE`),
  INDEX `fk_CARACTERISTICAS_X_INMUEBLE_INMUEBLE1_idx` (`ID_INMUEBLE` ASC),
  INDEX `fk_CARACTERISTICAS_X_INMUEBLE_CARACTERISTICAS_INMUEBLE1_idx` (`ID_CARACTERISTICA_INMUEBLE` ASC),
  CONSTRAINT `fk_CARACTERISTICAS_X_INMUEBLE_INMUEBLE1`
    FOREIGN KEY (`ID_INMUEBLE`)
    REFERENCES `achala_inmo_db`.`INMUEBLES` (`ID_INMUEBLE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_CARACTERISTICAS_X_INMUEBLE_CARACTERISTICAS_INMUEBLE1`
    FOREIGN KEY (`ID_CARACTERISTICA_INMUEBLE`)
    REFERENCES `achala_inmo_db`.`CARACTERISTICAS_INMUEBLE` (`ID_CARACTERISTICA_INMUEBLE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`ESTADOS_PUBLICACION`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`ESTADOS_PUBLICACION` (
  `ID_ESTADO_PUBLICACION` INT NOT NULL,
  `N_ESTADO_PUBLICACION` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`ID_ESTADO_PUBLICACION`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`PUBLICACIONES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`PUBLICACIONES` (
  `ID_PUBLICACION` INT NOT NULL AUTO_INCREMENT,
  `N_PUBLICACION` VARCHAR(200) NOT NULL,
  `DESCRIPCION_PUBLICACION` VARCHAR(5000) NULL,
  `ID_TIPO_OPERACION` INT NOT NULL,
  `PRECIO` DOUBLE NOT NULL,
  `FEC_PUBLICACION` DATETIME NOT NULL,
  `FEC_BAJA` DATETIME NULL,
  `ID_ESTADO_PUBLICACION` INT NOT NULL,
  `ID_INMUEBLE` INT NOT NULL,
  `PRIORIDAD` INT NOT NULL,
  `FEC_MODIF` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID_PUBLICACION`),
  INDEX `fk_PUBLICACIONES_TIPOS_OPERACION1_idx` (`ID_TIPO_OPERACION` ASC),
  INDEX `fk_PUBLICACIONES_ESTADOS_PUBLICACION1_idx` (`ID_ESTADO_PUBLICACION` ASC),
  INDEX `fk_PUBLICACIONES_INMUEBLE1_idx` (`ID_INMUEBLE` ASC),
  CONSTRAINT `fk_PUBLICACIONES_TIPOS_OPERACION1`
    FOREIGN KEY (`ID_TIPO_OPERACION`)
    REFERENCES `achala_inmo_db`.`TIPOS_OPERACION` (`ID_TIPO_OPERACION`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PUBLICACIONES_ESTADOS_PUBLICACION1`
    FOREIGN KEY (`ID_ESTADO_PUBLICACION`)
    REFERENCES `achala_inmo_db`.`ESTADOS_PUBLICACION` (`ID_ESTADO_PUBLICACION`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PUBLICACIONES_INMUEBLE1`
    FOREIGN KEY (`ID_INMUEBLE`)
    REFERENCES `achala_inmo_db`.`INMUEBLES` (`ID_INMUEBLE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`AMBIENTES_X_INMUEBLE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`AMBIENTES_X_INMUEBLE` (
  `ID_AMBIENTE_X_INMUEBLE` INT NOT NULL,
  `ID_AMBIENTE` INT NOT NULL,
  `ID_INMUEBLE` INT NOT NULL,
  PRIMARY KEY (`ID_AMBIENTE_X_INMUEBLE`),
  INDEX `fk_AMBIENTES_X_INMUEBLE_AMBIENTES1_idx` (`ID_AMBIENTE` ASC),
  INDEX `fk_AMBIENTES_X_INMUEBLE_INMUEBLE1_idx` (`ID_INMUEBLE` ASC),
  CONSTRAINT `fk_AMBIENTES_X_INMUEBLE_AMBIENTES1`
    FOREIGN KEY (`ID_AMBIENTE`)
    REFERENCES `achala_inmo_db`.`AMBIENTES` (`ID_AMBIENTE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_AMBIENTES_X_INMUEBLE_INMUEBLE1`
    FOREIGN KEY (`ID_INMUEBLE`)
    REFERENCES `achala_inmo_db`.`INMUEBLES` (`ID_INMUEBLE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `achala_inmo_db`.`IMAGENES_X_INMUEBLE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `achala_inmo_db`.`IMAGENES_X_INMUEBLE` (
  `ID_IMAGEN_X_INMUEBLE` INT NOT NULL,
  `PATH` VARCHAR(500) NOT NULL,
  `ID_INMUEBLE` INT NOT NULL,
  PRIMARY KEY (`ID_IMAGEN_X_INMUEBLE`),
  INDEX `fk_IMAGENES_X_INMUEBLE_INMUEBLES1_idx` (`ID_INMUEBLE` ASC),
  CONSTRAINT `fk_IMAGENES_X_INMUEBLE_INMUEBLES1`
    FOREIGN KEY (`ID_INMUEBLE`)
    REFERENCES `achala_inmo_db`.`INMUEBLES` (`ID_INMUEBLE`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


