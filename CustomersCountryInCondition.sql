SELECT CustomerIdentifier ,
       CompanyName ,
       c.[Name] AS CountryName
FROM   dbo.Customers AS Cust
       INNER JOIN dbo.Countries AS c ON c.CountryIdentifier = Cust.CountryIdentifier
WHERE  Cust.CountryIdentifier IN ( 8, 9 );
