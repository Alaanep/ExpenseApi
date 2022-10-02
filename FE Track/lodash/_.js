
const _ = {
    clamp: function (number, lower, upper){
        // if(number<lower){
        //   return lower;
        // } else if(number>upper){
        //     return upper;
        // } else if(number>=lower && number<=upper){
        //     return number;
        // }
        let clamped = Math.max(number, lower);
        return  Math.min(clamped, upper);
      },
    inRange: function(number, start=0, end){
        if(end===undefined){
            end=start;
            start=0;
        }
        if(start>end){
            [start, end]=[end, start];
        }
        if(number<start){
            return false;
        }else if(number>=end){
            return false;
        }else if(number>=start && number<end){
            return true;
        }
    },
    words: function(string){
        return string.split(" ");
    },
    pad: function(string, length){
        if(string.length>=length){
            return string;
        } else {
            const diff = length-string.length;
            const startPadding = Math.floor(diff/2);
            const endPadding = Math.ceil(diff/2);
            return " ".repeat(startPadding)+string+" ".repeat(endPadding);
        }
        
    },
    has: function(obj, k){
        if(k in obj){
            return true;
        }
        return false;
    },

    invert: function(obj){
        const invertedObject={};
        for(key in obj){
            invertedObject[obj[key]]=key;
        }
        return invertedObject;
    },
    findKey: function(obj, predicate) {
        for(key in obj){
            if(predicate(obj[key])){
                return key;
            }
        }
        return undefined;
    },
    drop: function(arr, number=1){
        return arr.slice(number);
    },
    dropWhile: function(arr, predicate){
        // const copyArr= [...arr];
        // for(let i=0; i<copyArr.length; i++){
        //     if(predicate(copyArr[i], i, copyArr)){
        //         copyArr.shift();
        //     };
        // }
        // return copyArr;

        const dropNumber = arr.findIndex((element, index)=>{
            return !predicate(element, index, arr);
        });
        const droppedArray = this.drop(arr, dropNumber);
        return droppedArray;
    },
    chunk: function(arr, size=1){
        const copyArr=[...arr];
        const arrayChunks= [];
        for(let i =0; i < copyArr.length; i+=size){
            let arrayChunk = copyArr.slice(i, i+size);
            arrayChunks.push(arrayChunk);
        }
        return arrayChunks;

    }

};

//console.log(_.invert({a: "aa", b: "bb"})); 

// Do not write or modify code below this line.
module.exports = _;