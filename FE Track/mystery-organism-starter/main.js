// Returns a random DNA base
const returnRandBase = () => {
  const dnaBases = ['A', 'T', 'C', 'G'];
  return dnaBases[Math.floor(Math.random() * 4)];
};

// Returns a random single stand of DNA containing 15 bases
const mockUpStrand = () => {
  const newStrand = [];
  for (let i = 0; i < 15; i++) {
    newStrand.push(returnRandBase());
  }
  return newStrand;
};


const pAequorFactory = (num, dna)=>{
return ({
  specimenNum: num,
  dna: dna,
  mutate: function(){
    const rand = Math.floor(Math.random() * this.dna.length);
    const currBase = this.dna[rand];
    let newBase=returnRandBase();
    this.dna[rand]=newBase;
    while(currBase===newBase){
      newBase=returnRandBase();
      this.dna[rand]=newBase;
    }
    return this.dna;
  },
  compareDNA: function(pAequor){
    console.log(pAequor.dna);
    console.log(this.dna);
    let identicalBase = 0;
    for(let i = 0; i<this.dna.length; i++){
      if(this.dna[i]===pAequor.dna[i]){
        console.log(this.dna[i], i);
        identicalBase++;
      }
    }
    console.log(identicalBase);
    return `specimen #${this.specimenNum} and specimen #${pAequor.specimenNum} have ${Math.round((identicalBase/this.dna.length)*100)}% DNA in common`;
  },
  willLikelySurvive: function(){
    let counter =0;
    this.dna.forEach(element => {
      if(element === "C" || element==="G" ){
        console.log(element);
        counter++;
      }
    });
    const rate = 0.6;
    console.log(counter);
    console.log(counter/this.dna.length);
    if((counter/this.dna.length)>=rate){
      return true;
    } else {
      return false;
    }
  } 
})
}

const Create30pAequor = ()=>{
  const batchLength=30;
  const batch=[];
  for(let i =0; i<batchLength; i++ ){
    const num = i+1;
    let newPAequar = pAequorFactory(num, mockUpStrand() );
    if(newPAequar.willLikelySurvive()){
      batch.push(newPAequar)
    } else {
      while(!newPAequar.willLikelySurvive()){
        newPAequar=pAequorFactory(num, mockUpStrand() );
      }
      batch.push(newPAequar);
    }
  }
  return batch;
}
const pAequor1=pAequorFactory(1,mockUpStrand());
const pAequor2=pAequorFactory(2,mockUpStrand());
const batch = Create30pAequor();
console.log(batch);





