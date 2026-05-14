CREATE DATABASE IF NOT EXISTS FullSound;
USE FullSound;

DROP TABLE IF EXISTS agenda;
DROP TABLE IF EXISTS Clientes;

CREATE TABLE Clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    celular VARCHAR(20) NOT NULL,
    tipo_veiculo ENUM('SUV', 'SEDAN', 'HATCH') NOT NULL
);

CREATE TABLE agenda (
    id_servico INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL,
    data_agendamento DATE NOT NULL,
    hora_agendamento TIME NOT NULL,
    tipo_servico ENUM(
        'Instalação',
        'Manutenção',
        'Sonorização de evento',
        'Locação de equipamentos'
    ) NOT NULL,
    valor DECIMAL(10,2) DEFAULT 0.00,

    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
);

INSERT INTO Clientes (nome, celular, tipo_veiculo) VALUES
('Cliente Teste', '11999999999', 'HATCH'),
('Maria Silva', '11988888888', 'SEDAN'),
('João Santos', '11977777777', 'SUV');

INSERT INTO agenda 
(id_cliente, data_agendamento, hora_agendamento, tipo_servico, valor)
VALUES
(1, CURDATE(), '09:00:00', 'Instalação', 0.00),
(2, CURDATE(), '14:30:00', 'Manutenção', 0.00),
(3, CURDATE(), '17:00:00', 'Sonorização de evento', 0.00);