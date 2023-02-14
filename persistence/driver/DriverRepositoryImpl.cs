using domain.common;
using domain.driver;
namespace persistence.driver;

public class DriverRepositoryImpl : DriverRepository
{

    List<Driver> drivers = new List<Driver>{
        new Driver (
            address:"Shola",
            dateOfBirth: new DateTime(),
            drivingLicense: new Uri(""),
            email:"nahomHab@gmail.com",
            firstName:"Nahom",
            lastName:"Habtamu",
            gender:Gender.MALE,
            phoneNumber:new MobileNumber("0926849888")
        ),
        new Driver (
            address:"Shola",
            dateOfBirth: new DateTime(),
            drivingLicense: new Uri(""),
            email:"dagiHab@gmail.com",
            firstName:"Dagm",
            lastName:"Habtamu",
            gender:Gender.MALE,
            phoneNumber:new MobileNumber("0947977597")
        ),
        new Driver (
            address:"Kebena",
            dateOfBirth: new DateTime(),
            drivingLicense: new Uri(""),
            email:"fikir@gmail.com",
            firstName:"Fikir",
            lastName:"Tigneh",
            gender:Gender.MALE,
            phoneNumber:new MobileNumber("0911567788")
        ),
        new Driver (
            address:"Shola",
            dateOfBirth: new DateTime(),
            drivingLicense: new Uri(""),
            email:"mah@gmail.com",
            firstName:"Mahder",
            lastName:"Tibebu",
            gender:Gender.FEMALE,
            phoneNumber:new MobileNumber("0911778899")
        )
    };

    public Task<Driver?> Get(string id)
    {
        return Task.Run(() => drivers.FirstOrDefault(d => d.Id.Equals(id)));
    }

    public Task Save(Driver entity)
    {
        return Task.Run(() => drivers.Add(entity));
    }
}