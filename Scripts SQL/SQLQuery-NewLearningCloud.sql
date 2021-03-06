/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT a.usu_id, a.usu_nome, a.usu_sobrenome, a.usu_dataNascimento, a.usu_genero, a.usu_generoDescricao, 
a.usu_fotoPerfil, a.usu_status, a.usu_dataCadastro,
b.uac_id, b.uac_nivelAcesso, b.uac_email, b.uac_emailConfirmed, b.uac_passwordHash, b.uac_securityStamp, b.uac_phoneNumber, 
b.uac_phoneNumberConfirmed, b.uac_twoFactorEnabled, b.uac_lockoutEndDateUtc, b.uac_lockoutEnabled, b.uac_accessFailedCount, 
b.uac_userName, b.uac_fk_usuario, c.ulo_loginProvider, c.ulo_providerKey, c.ulo_usuarioId
FROM NewLearningCloud_Usuario AS a
INNER JOIN NewLearningCloud_UsuarioAcesso AS b ON a.usu_id = b.uac_fk_usuario
LEFT JOIN NewLearningCloud_UsuariosLogins AS c ON b.uac_id = c.ulo_usuarioId
------------------------------------------------------------------------------
--Administrador
WHERE a.usu_id = 'bec2b8eb-aa30-4a54-b40a-92c8b97cad6f'
--Google
--WHERE a.usu_id = '68d9ce76-ebaa-4efd-ab27-3df130682870'
--Facebook
--WHERE a.usu_id = '398b136f-bb65-4a7b-b919-ec410e8c4603'
------------------------------------------------------------------------------
--Administrador
UPDATE NewLearningCloud_UsuarioAcesso SET uac_emailConfirmed = 0 where uac_id = '31a5251d-dd29-4d3f-b347-fa07ff7e17f9'
--Google
UPDATE NewLearningCloud_UsuarioAcesso SET uac_emailConfirmed = 0 where uac_id = '3609b2f0-b5fe-48e4-bb7c-dd531b3b6695'
UPDATE NewLearningCloud_UsuarioAcesso SET uac_passwordHash = NULL where uac_id = '3609b2f0-b5fe-48e4-bb7c-dd531b3b6695'
--Facebook
UPDATE NewLearningCloud_UsuarioAcesso SET uac_emailConfirmed = 0 where uac_id = '46ab0e1b-5a3b-407a-9f8e-b450fd1e1f3f'
UPDATE NewLearningCloud_UsuarioAcesso SET uac_passwordHash = NULL where uac_id = '46ab0e1b-5a3b-407a-9f8e-b450fd1e1f3f'

