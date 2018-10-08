export class Weather {
    temperature: Temp;
    location: Loc;
    Humidity: number;
}
export class Temp{
    value: number;
    format: string;
}
export class Loc {
    city: string;
    country: string;
    region :string;
}
