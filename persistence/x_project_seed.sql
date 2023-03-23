/* Cargo Owner Seed */

insert into cargoowner values(
	'4650df78-9132-44d8-9168-4f90e31616e1','Cargo Owner 1','0926849881',
	'cowner1@gmail.com','Shola, Addis Ababa','1250df78-9132-44d8-9168-4f90e31616e4.png',
	'abebe gemechu','0911041221', 'Shola, Addis Ababa', 'abebe@gmail.com', 'NN'
);

insert into cargoowner values(
	'4650df78-9132-44d8-9168-4f90e31616e2','Cargo Owner 2','0926849882',
	'cowner2@gmail.com','Shola, Addis Ababa','0650df78-9132-44d8-9168-4f90e31616e4.png',
	'abebe gemechu','0911041221', 'Shola, Addis Ababa', 'abebe@gmail.com', 'NN'
);

insert into cargoowner values(
	'4650df78-9132-44d8-9168-4f90e31616e3','Cargo Owner 3','0926849883',
	'cowner3@gmail.com','Shola, Addis Ababa','9650df78-9132-44d8-9168-4f90e31616e4.png',
	'abebe gemechu','0911041221', 'Shola, Addis Ababa', 'abebe@gmail.com', 'NN'
);

/* Auction Seed */

insert into auction values(
	'1110df78-9132-44d8-9168-4f90e31616e1', '4650df78-9132-44d8-9168-4f90e31616e1',
	'HEAVY',20,'Idk','Addis Ababa, Shola','02-03-2023',
	'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum',
	135.45,180.90,'12:00','02:00'
);

insert into auction values(
	'1110df78-9132-44d8-9168-4f90e31616e2', '4650df78-9132-44d8-9168-4f90e31616e2',
	'LIGHT',20,'some place','Addis Ababa, Shola','03-04-2023',
	'beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit',
	35.45,43.90,'11:00','03:00'
);

insert into auction values(
	'1110df78-9132-44d8-9168-4f90e31616e3', '4650df78-9132-44d8-9168-4f90e31616e3',
	'MEDIUM',20,'someplace else','Addis Ababa, Shola','04-05-2023',
	'Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam vel illum qui dolorem eum fugiat',
	55.45,73.90,'02:00','04:00'
);


/* Driver Seed */

insert into Driver values(
	'7210df78-9132-44d8-9168-4f90e31616e1',
	'Nahom Habtamu','0926849888','nahom@gmail.com',
	'0','04-05-2023', 'Addis Ababa, Shola',
	'1250df78-9132-44d8-9168-4f90e31616e4.png'
);

insert into Driver values(
	'7210df78-9132-44d8-9168-4f90e31616e2',
	'Dagim Habtamu','0947977597','dagim@gmail.com',
	'0','04-05-2023', 'Addis Ababa, Shola',
	'8720df78-9132-44d8-9168-4f90e31616e4.png'
);

insert into Driver values(
	'7210df78-9132-44d8-9168-4f90e31616e3',
	'Tigist Bekele','0911041221','tg@gmail.com',
	'1','04-05-2023', 'Addis Ababa, Shola',
	'5460df78-9132-44d8-9168-4f90e31616e4.png'
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