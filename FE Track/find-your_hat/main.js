const prompt = require('prompt-sync')({sigint: true});

const hat = '^';
const hole = 'O';
const fieldCharacter = '░';
const pathCharacter = '*';

class Field{
    constructor(field){
        this.field=field;
        this.playerLocation={
                "row": 0,
                "col": 0
        }
        this.gameOver=false;
    }

    print(){
        let str="";
        this.field.forEach(row => {
            row.forEach(el=>{
                str+=el;
            });
            str+= "\n";
          });
          console.log(str);
        //console.log(this.field.join(""));
    }

    updateLocation(move){
        if(move=='d'){
            this.playerLocation.col++;
        }else if(move==='s'){
            this.playerLocation.row++;
        }else if(move==='a'){
            this.playerLocation.col--;
        } else if(move==='w'){
            this.playerLocation.row--;
        }
        this.checkForGameOver();
    }

    checkForGameOver(){
        //console.log(this.field[this.playerLocation.row][this.playerLocation.col]);
        if (this.playerLocation.row<0 || 
            this.playerLocation.col<0 || 
            this.playerLocation.col>=this.field[0].length ||
            this.playerLocation.row>=this.field.length ){
            console.log("You are out of field bounds");
            this.gameOver=true;
            return true;
        }
        
        if(this.field[this.playerLocation.row][this.playerLocation.col]==='O'){
            this.field[this.playerLocation.row][this.playerLocation.col]=pathCharacter;
            myField.print();
            console.log("You fell into hole");
            this.gameOver=true;
            return true;
        }else if(this.field[this.playerLocation.row][this.playerLocation.col]==='^'){
            this.field[this.playerLocation.row][this.playerLocation.col]=pathCharacter;
            myField.print();
            console.log("Gongrats, you found your hat!");
            this.gameOver=true;
            return true;
        } else {
            this.field[this.playerLocation.row][this.playerLocation.col]=pathCharacter;
            myField.print();
        }
    }
    static getRandomValue(val){
        return Math.floor(Math.random()*val);
    }

    static generateField(height=3, width=3, numOfHoles=2){
        var field = Array.from(Array(height), () => new Array(width));
        for(let i=0; i < height; i++){
            for(let j=0; j < width; j++){
                field[i][j]=fieldCharacter
            }
        }
        field[0][0]=pathCharacter;
        
        let randomRow = this.getRandomValue(height);
        let randomCol = this.getRandomValue(width);

        if(field[randomRow][randomCol]===fieldCharacter){
            field[randomRow][randomCol]=hat;
        } else {
            while(field[randomRow][randomCol]!==fieldCharacter){
                randomRow = this.getRandomValue(height);
                randomCol = this.getRandomValue(width);
            }
            field[randomRow][randomCol]=hat;
        }

        
        for(let i= 0; i <= numOfHoles; i++){
            let randomHoleRow = this.getRandomValue(height);
            let randomHoleCol = this.getRandomValue(width);

            if(field[randomRow][randomCol]===fieldCharacter){
                field[randomRow][randomCol]=hat;
            } else {
                while(field[randomHoleRow][randomHoleCol]!==fieldCharacter){
                    randomHoleRow = this.getRandomValue(height);
                    randomHoleCol = this.getRandomValue(width);
                }
                field[randomHoleRow][randomHoleCol]=hole;
            }
        }
        console.log(field);
        return field;
    }

    
}

// const myField=new Field([
//     ['*', '░', 'O'],
//     ['░', 'O', '░'],
//     ['░', '^', '░'],
//   ]);

const myField=new Field(Field.generateField(10,10, 10));
console.log("Press 'w' to move up, 'd' to move right, 's' to move down, 'a' to move left, 'ctrl+c'to exit.");
myField.print();
while(!myField.gameOver){
    let input = prompt("which way?");
    myField.updateLocation(input);   
}



  