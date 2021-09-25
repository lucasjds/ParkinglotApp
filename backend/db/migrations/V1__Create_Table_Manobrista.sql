﻿CREATE TABLE IF NOT EXISTS `manobrista` (
	`codigo` BIGINT(20) NOT NULL AUTO_INCREMENT,
	`nome` VARCHAR(100) NOT NULL,
	`data_nascimento` DATETIME NOT NULL,
	`cpf` VARCHAR(50) NULL DEFAULT NULL,
	PRIMARY KEY (`codigo`) USING BTREE
) ;