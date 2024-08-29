export class Client{
    
    clientId: string = "";
    firstName: string = "";
    lastName: string = "";
    cpf: string = "";
    phone: string = "";
    role: Roles = Roles.none;
    birth: Date = new Date();
    registerDate: Date = new Date();
    //getters
    public get fullName(): string | undefined {
        return `${this.firstName} ${this.lastName}`;
    }
    public get age(): number{
        let timeDiff = Math.abs(Date.now() - this.birth.getDate());
        return Math.floor((timeDiff / (1000 * 3600 * 24)) / 365.25);
    }

}

export enum Roles {
    none,
    administrator,
    client,
}