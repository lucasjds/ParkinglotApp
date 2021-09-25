CREATE TABLE IF NOT EXISTS `manobra` (
	`codigo` BIGINT(20) NOT NULL AUTO_INCREMENT,
	`codigo_carro` BIGINT(20) NOT NULL,
	`codigo_manobrista` BIGINT(20) NOT NULL,
	`data_hora_manobra` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`codigo`) USING BTREE,
	FOREIGN KEY (codigo_carro) REFERENCES carro(codigo),
	FOREIGN KEY (codigo_manobrista) REFERENCES manobrista(codigo)
) ;