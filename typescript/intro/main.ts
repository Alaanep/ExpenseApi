export {}

let message = "hello world!";
console.log(message);

let x = 10;
const y = 10;

let sum;
const title="Code Evolution";

let isBeginner: boolean = true;
let total: number = 0;

let name: string = 'Vishwas';
let sentence: string = `My name is ${name}
I am a beginner in Typescript`;

let n: null = null;
let u: undefined = undefined;

let list1: number[]=[1,2,3];
let list2: Array<number>=[1,2,3];

let person1: [string, number]= ['Chris', 22];

enum Color {Red=5, Green, Blue};
let c: Color = Color.Green;

let myVariable: unknown = 10;

function hasName(obj: any): obj is {name: string}{
    return !!obj &&
    typeof obj==="object" && "name" in obj
}
if(hasName(myVariable)){
    console.log(myVariable);
}

let a;
a=10;
a=true;

let b = 20;
//b=true;

let multiType: number | boolean;
multiType=20;
multiType=true;

function add(num1: number, num2: number=10){   
    if(num2) return num1 + num2;
    else return num1;
}

add(5,10);
//add(5, 'what');

interface Person {
    firstName: string,
    lastName: string
}

function fullName(person: {firstName: string, lastName: string}){
    console.log(`${person.firstName} ${person.lastName}`);
}

function fullName1(person: Person){
    console.log(`${person.firstName} ${person.lastName}`);
}

let p = {firstName: "Bruce", lastName: "Wayne"};
fullName(p);
fullName1(p);

class Employee {
    employeeName: string;
    constructor(name: string){
        this.employeeName=name;
    }
    greet(){
        console.log(`Good Morning ${this.employeeName}`); 
    }
}

class Manager extends Employee {
    constructor(managerName: string){
        super(managerName);
    }

    delegateWork(){
        console.log("Manager delegating tasks");
    }
}

let emp1 = new Employee('Vishwas');
console.log(emp1.employeeName);
emp1.greet();
let m1 = new Manager("Bruce");
m1.delegateWork();
m1.greet();
console.log(m1.employeeName);




 


//console.log(c);
//console.log(sentence);