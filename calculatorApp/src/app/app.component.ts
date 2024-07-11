import { Component } from '@angular/core';
import { CalculatorService } from './calculator.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'calculatorApp';
  result: any;
  currentPosition = 1;

  constructor(private calculatorService: CalculatorService) {}

  ngOnInit(): void {
    this.get(1);
  }
  
  add(): void {
    this.calculatorService.add().subscribe((data) => {
      this.result = data.toString();
    });
  }

  subtract(): void {
    this.calculatorService.subtract().subscribe((data) => {
      this.result = data.toString();
    });
  }

  divide(): void {
    this.calculatorService.divide().subscribe((data) => {
        this.result = data.toString();
    },
    (error) => {
        if (error.status === 400) {
          alert("Division by zero is not allowed.");          
        }
    });
  }

  multiply(): void {
    this.calculatorService.multiply().subscribe((data) => {
      this.result = data.toString();
    });
  }

  get(position: number): void {
    this.calculatorService.get(position).subscribe((data) => {
      this.result = data.toString();
    });
    this.currentPosition = position;
  }

  pos(num: number){
    if (this.currentPosition == 1) {
      this.calculatorService.pos1(num).subscribe((data) => {
        this.result = data.toString();
      });    
    }
    else {
      this.calculatorService.pos2(num).subscribe((data) => {
        this.result = data.toString();
      });    
    }

  }

  clear(){
    this.calculatorService.clear(this.currentPosition).subscribe((data) => {
      this.result = data.toString();
    });        
  }

  number(num: number){
    if (this.result == 0){
      this.result = num.toString();  
    }
    else {
      this.result = this.result.toString() + num.toString();
    }

  }

  enter(){
    if (this.result > 1000 || this.result < -1000) {
      alert("Number must be between -1000 and 1000");
    }
    else {

    if (this.currentPosition == 1){
      this.calculatorService.pos1(this.result).subscribe((data) => {
        this.result = data.toString();
      });        
    }
    else {
      this.calculatorService.pos2(this.result).subscribe((data) => {
        this.result = data.toString();
      });           
    }
  }
  }

  negative(){
    this.result *= -1;
  }

  
}
