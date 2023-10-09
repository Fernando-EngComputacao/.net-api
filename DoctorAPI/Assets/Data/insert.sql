INSERT INTO doctorapi.address (id, place, neighborhood, cep, city, uf, complement, number, active) VALUES (1, 'Rua Hélio da Silva Nogueira', 'Setor Cristina II Expansão', '75-389.328', 'Trindade', 'GO', 'Casa', 's/n', 1);
INSERT INTO doctorapi.address (id, place, neighborhood, cep, city, uf, complement, number, active) VALUES (2, 'Rua Magali da Silva Nogueira', 'Setor Cristina II Expansão', '75-389.325', 'Trindade', 'GO', 'Casa', 's/n', 1);
INSERT INTO doctorapi.address (id, place, neighborhood, cep, city, uf, complement, number, active) VALUES (3, 'Rua Lucas da Silva Nogueira', 'Setor Cristina II Expansão', '75-389.320', 'Trindade', 'GO', 'Casa', 's/n', 1);
INSERT INTO doctorapi.address (id, place, neighborhood, cep, city, uf, complement, number, active) VALUES (4, 'Rua Maria Tereza Nogueira', 'Setor Cristina II Expansão', '75-389.324', 'Trindade', 'GO', 'Casa', 's/n', 1);
INSERT INTO doctorapi.address (id, place, neighborhood, cep, city, uf, complement, number, active) VALUES (5, 'Rua Tereza Nogueira', 'Setor Cristina II Expansão', '75-389.323', 'Trindade', 'GO', 'Casa', 's/n', 1);
INSERT INTO doctorapi.doctors (id, name, crm, email, specialty, telephone, active, addressId) VALUES (1, 'Fernando Furtado', '1546432', 'fernando.furtado@email.com', 'Ortopedia', '62', 1, 1);
INSERT INTO doctorapi.doctors (id, name, crm, email, specialty, telephone, active, addressId) VALUES (2, 'Maria Eduarda', '1546432', 'maria.eduarda@email.com', 'Ortopedia', '64', 1, 2);
INSERT INTO doctorapi.patients (id, name, birth, telephone, email, active, addressId) VALUES (1, 'Lara', '2000/11/28', '50', 'lara.silva@email.com', 1, 3);
INSERT INTO doctorapi.patients (id, name, birth, telephone, email, active, addressId) VALUES (2, 'Letícia', '2000/11/28', '50', 'leticia.breno@email.com', 1, 4);
