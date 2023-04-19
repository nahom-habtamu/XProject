create table if not exists CargoOwner(
	id varchar(64) primary key,
	name varchar(100) not null,
	phoneNumber varchar(100) not null,
	email varchar(100) not null,
	specificAddress varchar(200) not null,
	tradeLicense varchar(255) not null,
	userName varchar(100) not null,
	password varchar(255) not null,
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
	minPickUpTime varchar(8) not null,
	maxPickUpTime varchar(8) not null,
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
	drivingLicense varchar(255) not null,
	userName varchar(100) not null,
	password varchar(255) not null
);

create table if not exists VehicleOwner(
	id varchar(64) primary key,
	name varchar(100) not null,
	phoneNumber varchar(100) not null,
	email varchar(100) not null,
	companyName varchar(100) not null,
	tradeLicense varchar(255) not null,
	userName varchar(100) not null,
	password varchar(255) not null
);

create table if not exists Vehicle(
  id varchar(64) primary key,
  plateNumber varchar(10) not null,
  ownerId varchar(64) not null,
  driverId varchar(64) not null,
  city varchar(50) not null,
  type varchar(50) not null,
  loadType varchar(50) not null,
  manufacturedDate date not null,
  make varchar(50) not null,
  model varchar(50) not null,
  loadCapacity varchar(20) not null,
  color varchar(50) not null,
  carImage varchar(255) not null,
  libreImage varchar(255) not null,
  insuranceImage varchar(255) not null,
  libreExpiryDate date not null,
  insuranceExpiryDate date not null,
  driverIdentificationDocument varchar(255) not null,
  CONSTRAINT ownerId
    FOREIGN KEY(ownerId) 
    REFERENCES VehicleOwner(id),
  CONSTRAINT driverId
      FOREIGN KEY(driverId) 
    REFERENCES Driver(id)
);

create table if not exists Bid(
	id varchar(64) primary key,
	auctionId varchar(64) not null,
	driverId varchar(64) not null,
	pricePerKilogram float not null,
	additionalInformation varchar(255) not null,
	CONSTRAINT auctionId
    	FOREIGN KEY(auctionId) 
    	REFERENCES Auction(id),
  	CONSTRAINT driverId
      	FOREIGN KEY(driverId) 
    	REFERENCES Driver(id)
);