create table if not exists CargoOwner(
	id varchar(64) primary key,
	name varchar(100) not null,
	phoneNumber varchar(100) not null,
	email varchar(100) not null,
	specificAddress varchar(200) not null,
	tradeLicense varchar(255) not null,
	pointPersonName varchar(100) not null,
	pointPersonPhoneNumber varchar(100) not null,
	pointPersonSpecificAddress varchar(200) not null,
	pointPersonEmail varchar(100) not null,
	pointPersonPosition varchar(100) not null
);

create table if not exists Auction(
	id varchar(64) primary key,
	cargoOwnerId varchar(64) not null,
	typeOfCargo varchar(15) not null,
	totalWeightOfCargo int not null,
	deliveryPlace varchar(100) not null,
	pickUpPlace varchar(100) not null,
	plannedPickUpDate date not null,
	otherInformationAboutCargo varchar(255) not null,
	minPricePerHundredKg float not null,
	maxPricePerHundredKg float not null,
	minPickUpTime varchar(5) not null,
	maxPickUpTime varchar(5) not null,
	CONSTRAINT cargoOwnerId
      FOREIGN KEY(cargoOwnerId) 
	  REFERENCES CargoOwner(id)
);

do
$$
begin
	create type Gender AS ENUM ('0','1');	
	exception when DUPLICATE_OBJECT then
	raise notice 'type "gender" exists, skipping CREATE TYPE';
end
$$;

create table if not exists Driver(
	id varchar(64) primary key,
	name varchar(100) not null,
	phoneNumber varchar(100) not null,
	email varchar(100) not null,
	gender Gender not null,
	dateOfBirth date not null,
	specificAddress varchar(100) not null,
	drivingLicense varchar(255) not null
);