/* Options:
Date: 2019-07-07 18:22:27
Version: 5.50
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://localhost:5000

//GlobalNamespace: 
//MakePropertiesOptional: True
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion: 
//AddDescriptionAsComments: True
//IncludeTypes: 
//ExcludeTypes: 
//DefaultImports: 
*/


interface IReturn<T>
{
}

interface IReturnVoid
{
}

// @DataContract
interface Country
{
    // @DataMember(Name="name")
    name?: string;

    // @DataMember(Name="mcc")
    mobileCountryCode?: string;

    // @DataMember(Name="cc")
    countryCode?: string;

    // @DataMember(Name="pricePerSMS")
    pricePerSMS?: number;
}

type State = "Success" | "Failed";

// @DataContract
interface Sms
{
    // @DataMember(Name="dateTime")
    dateTime?: string;

    // @DataMember(Name="mcc")
    mobileCountryCode?: string;

    // @DataMember(Name="from")
    from?: string;

    // @DataMember(Name="to")
    to?: string;

    // @DataMember(Name="price")
    price?: number;

    // @DataMember(Name="state")
    state?: State;
}

interface StatisticRecord
{
    day?: number;
    mcc?: string;
    pricePerSms?: number;
    count?: number;
    totalPrice?: number;
}

interface HelloResponse
{
    result?: string;
}

interface SentSmsResponse
{
    totalCoint?: number;
    items?: Sms[];
}

// @Route("/countries", "GET")
interface GetCountries extends IReturn<Country[]>
{
}

// @Route("/hello")
// @Route("/hello/{Name}")
interface Hello extends IReturn<HelloResponse>
{
    name?: string;
}

// @Route("/sms/send")
interface SendSms extends IReturn<State>
{
    from?: string;
    to?: string;
    text?: string;
}

// @Route("/sms/sent")
interface SentSms extends IReturn<SentSmsResponse>
{
    dateTimeFrom?: string;
    dateTimeTo?: string;
    skip?: number;
    take?: number;
}

// @Route("/statistics")
interface Staticstics extends IReturn<StatisticRecord[]>
{
    dateFrom?: string;
    dateTo?: string;
    mccList?: string;
}

