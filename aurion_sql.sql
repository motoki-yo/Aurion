/* T A B E L A S   P R I N C I P A I S */

/* Tabela do usuario*/
DROP TABLE IF EXISTS usuario;
CREATE TABLE usuario(
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    nick VARCHAR(40) UNIQUE NOT NULL,
    senha VARCHAR(40) NOT NULL,
    pontos INTEGER DEFAULT 0,
    exc CHAR DEFAULT 'n'
);
/* Tabela do usuario*/


/* Tabela de jogos*/
DROP TABLE IF EXISTS jogo;
CREATE TABLE jogo(
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    nome VARCHAR(30) UNIQUE NOT NULL,
);
/* Tabela de jogos*/


/* Tabela de perguntas*/
DROP TABLE IF EXISTS tema;
CREATE TABLE tema(
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    respondido CHAR 
);
/* Tabela de perguntas*/

/* -------------------------------------------------*/


/* T A B E L A S   D E   L I G A Ç Ã O  */

/* Tabela de usuario_jogo*/
DROP TABLE IF EXISTS usuario_jogo;
CREATE TABLE usuario_jogo(
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    id_usuario INTEGER NOT NULL,
    id_jogo INTEGER NOT NULL,
    FOREIGN KEY(id_usuario) REFERENCES usuario(id),
    FOREIGN KEY(id_jogo) REFERENCES jogo(id)
);
/* Tabela de jogos*/


/* Tabela de usuario_pergunta*/
DROP TABLE IF EXISTS usuario_tema;
CREATE TABLE usuario_tema(
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    id_usuario INTEGER NOT NULL,
    id_tema INTEGER NOT NULL,
    FOREIGN KEY(id_usuario) REFERENCES usuario(id),
    FOREIGN KEY(id_tema) REFERENCES tema(id),
    acertos INTEGER
);
/* Tabela de jogos*/

/* -------------------------------------------------*/

