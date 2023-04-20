/* Cargo Owner Seed */

insert into cargoowner values(
	'4650df78-9132-44d8-9168-4f90e31616e1','Cargo Owner 1','0926849881',
	'cowner1@gmail.com','Shola, Addis Ababa','65650df78-9132-44d8-9168-4f90e31616e4.png','username','password',
	'abebe gemechu','0911041221', 'Shola, Addis Ababa', 'abebe@gmail.com', 'NN'
);

insert into cargoowner values(
	'4650df78-9132-44d8-9168-4f90e31616e2','Cargo Owner 2','0926849882',
	'cowner2@gmail.com','Shola, Addis Ababa','1230df78-9132-44d8-9168-4f90e31616e4.png','username','password',
	'abebe gemechu','0911041221', 'Shola, Addis Ababa', 'abebe@gmail.com', 'NN'
);

insert into cargoowner values(
	'4650df78-9132-44d8-9168-4f90e31616e3','Cargo Owner 3','0926849883',
	'cowner3@gmail.com','Shola, Addis Ababa','0650df78-9132-44d8-9168-4f90e31616e4.png','username','password',
	'abebe gemechu','0911041221', 'Shola, Addis Ababa', 'abebe@gmail.com', 'NN'
);

/* Auction Seed */

insert into auction values(
	'1110df78-9132-44d8-9168-4f90e31616e1', '4650df78-9132-44d8-9168-4f90e31616e1',
	'HEAVY',20,'Idk','Addis Ababa, Shola','02-03-2023',
	'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum',
	135.45,180.90,'12:00','02:00','2023-04-20 11:43:00'
);

insert into auction values(
	'1110df78-9132-44d8-9168-4f90e31616e2', '4650df78-9132-44d8-9168-4f90e31616e2',
	'LIGHT',20,'some place','Addis Ababa, Shola','03-04-2023',
	'beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit',
	35.45,43.90,'11:00','03:00','2023-04-20 11:44:00'
);

insert into auction values(
	'1110df78-9132-44d8-9168-4f90e31616e3', '4650df78-9132-44d8-9168-4f90e31616e3',
	'MEDIUM',20,'someplace else','Addis Ababa, Shola','04-05-2023',
	'Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam vel illum qui dolorem eum fugiat',
	55.45,73.90,'02:00','04:00','2023-04-20 11:45:00'
);


/* Driver Seed */

insert into Driver values(
	'7210df78-9132-44d8-9168-4f90e31616e1',
	'Nahom Habtamu','0926849888','nahom@gmail.com',
	'0','04-05-2023', 'Addis Ababa, Shola',
	'1250df78-9132-44d8-9168-4f90e31616e4.png',
	'username','password'
);

insert into Driver values(
	'7210df78-9132-44d8-9168-4f90e31616e2',
	'Dagim Habtamu','0947977597','dagim@gmail.com',
	'0','04-05-2023', 'Addis Ababa, Shola',
	'8720df78-9132-44d8-9168-4f90e31616e4.png',
	'username','password'
);

insert into Driver values(
	'7210df78-9132-44d8-9168-4f90e31616e3',
	'Tigist Bekele','0911041221','tg@gmail.com',
	'1','04-05-2023', 'Addis Ababa, Shola',
	'5460df78-9132-44d8-9168-4f90e31616e4.png',
	'username','password'
);


/* Vehicle Owner Seed */

insert into VehicleOwner values(
	'2150df78-9132-44d8-9168-4f90e31616e1',
	'Vehicle Owner 1', '0926849881', 'vo1@gmail.com',
	'VO1 Company', 
 	$$[
	   "2150df78-9132-44d8-9168-4f90e31616e1.jpg",
	   "2150df78-9132-44d8-9168-4f90e31616e1.jpg"
  	]$$,
	'vehicleowner-1',
	'vehicleowner1pass'
);

insert into VehicleOwner values(
	'2150df78-9132-44d8-9168-4f90e31616e2',
	'Vehicle Owner 2', '0926849882', 'vo2@gmail.com',
	'VO2 Company', 
 	$$[
	   "2150df78-9132-44d8-9168-4f90e31616e2.jpg",
	   "2150df78-9132-44d8-9168-4f90e31616e2.jpg"
  	]$$,
	'vehicleowner-2',
	'vehicleowner2pass'
);

insert into VehicleOwner values(
	'2150df78-9132-44d8-9168-4f90e31616e3',
	'Vehicle Owner 3', '0926849883', 'vo3@gmail.com',
	'VO3 Company', 
 	$$[
	   "2150df78-9132-44d8-9168-4f90e31616e3.jpg",
	   "2150df78-9132-44d8-9168-4f90e31616e3.jpg"
  	]$$,
	'vehicleowner-3',
	'vehicleowner3pass'
);

/* Vehicle Seed */

insert into Vehicle values(
	'3190df78-9132-44d8-9168-4f90e31616e1','00000',
	'2150df78-9132-44d8-9168-4f90e31616e1','7210df78-9132-44d8-9168-4f90e31616e1',
	'Addis Ababa','SOME_VEHICLE_TYPE','SOME_LOAD_TYPE','04-05-2022',
	'Make 1', 'Model 1','266KG','Green','7210df78-9132-44d8-9168-4f90e31616.jpg',
	'3210df78-9132-44d8-9168-4f90e31616.jpg','5210df78-9132-44d8-9168-4f90e31616.jpg',
	'03-05-2023','08-05-2023','2023-04-20 11:43:00',  	
	$$[
	   "x8-9132-44d8-9168-4f90e31616e1.jpg",
	   "x8-9132-44d8-9168-4f90e31616e1.jpg"
  	]$$
);

insert into Vehicle values(
	'3190df78-9132-44d8-9168-4f90e31616e2','00002',
	'2150df78-9132-44d8-9168-4f90e31616e2','7210df78-9132-44d8-9168-4f90e31616e2',
	'Addis Ababa','SOME_VEHICLE_TYPE_2','SOME_LOAD_TYPE_2','04-05-2022',
	'Make 2', 'Model 2','266KG','Red','1110df78-9132-44d8-9168-4f90e31616.jpg',
	'2810df78-9132-44d8-9168-4f90e31616.jpg','9010df78-9132-44d8-9168-4f90e31616.jpg',
	'03-05-2023','08-05-2023','2023-04-20 11:44:00',  	
	$$[
	   "y8-9132-44d8-9168-4f90e31616e1.jpg",
	   "y8-9132-44d8-9168-4f90e31616e1.jpg"
  	]$$
);

insert into Vehicle values(
	'3190df78-9132-44d8-9168-4f90e31616e3','00003',
	'2150df78-9132-44d8-9168-4f90e31616e3','7210df78-9132-44d8-9168-4f90e31616e3',
	'Addis Ababa','SOME_VEHICLE_TYPE_3','SOME_LOAD_TYPE_3','04-05-2022',
	'Make 3', 'Model 3','222KG','Yellow','3210df78-9132-44d8-9168-4f90e31616.jpg',
	'1210df78-9132-44d8-9168-4f90e31616.jpg','9010df78-9132-44d8-9168-4f90e31616.jpg',
	'03-05-2023','08-05-2023','2023-04-20 11:45:00', 	
	$$[
	   "z8-9132-44d8-9168-4f90e31616e1.jpg",
	   "z8-9132-44d8-9168-4f90e31616e1.jpg"
  	]$$
);

/* Bid Seed */

insert into Bid values(
	'9990df78-9132-44d8-9168-4f90e31616e1',
	'1110df78-9132-44d8-9168-4f90e31616e1',
	'7210df78-9132-44d8-9168-4f90e31616e1',
	900,
	'as opposed to using Content here, content here, making it look like readable readable English'
);

insert into Bid values(
	'9990df78-9132-44d8-9168-4f90e31616e2',
	'1110df78-9132-44d8-9168-4f90e31616e2',
	'7210df78-9132-44d8-9168-4f90e31616e2',
	1000,
	'with the release of Letraset sheets containing Lorem Ipsum passages, and more things'
);

insert into Bid values(
	'9990df78-9132-44d8-9168-4f90e31616e3',
	'1110df78-9132-44d8-9168-4f90e31616e3',
	'7210df78-9132-44d8-9168-4f90e31616e3',
	1100,
	'web page editors now use Lorem Ipsum as their default model text'
);