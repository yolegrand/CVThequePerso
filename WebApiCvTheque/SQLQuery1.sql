INSERT INTO dbo.Users(FirstName,LastName,Licence,Mail,PersonalMail,Pass,Box,
Phone,PersonalPhone, Zip, City, [PublicTransport],Street, Number, NationalityId, SocietyId, IsDelete) VALUES ('fabio','fafa',1
,'fabio@gmail.com','fabio@gmail.com',dbo.SP_HashPassword('laurent'),
4,1234561898,1237564898,7852,'Nivelles',1,'rue de toto', 15,2,1,0)