export interface Cliente {
    id: string;
    name: string;
    email: string;
    phone: string;
    birthDate: Date;
    addressList: Endereco[]
}

export interface Endereco {
    id: string;
    customerId: string;
    postalCode: string;
    street: string;
    streetNumber: Date;
    complementaryAddress: Date;
    city: Date;
    state: Date;
}