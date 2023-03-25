import { Component, OnInit } from '@angular/core';
import { HostListener } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})

export class CalculatorComponent implements OnInit {

  currentNumber: string = "";
  heldNumber: number | null = null;
  heldOperation: Operation | null = null;
  constructor() { }

  ngOnInit(): void { }

  onNumberClick(number: number) {
    if (this.currentNumber == null)
      this.currentNumber = "";

    this.currentNumber += number.toString();
  }

  period() {
    if (this.currentNumber == null)
      this.currentNumber = "";


    if (this.currentNumber.includes(".")) {
      return;
    }

    if (this.currentNumber == "") {
      this.currentNumber += "0.";
      return;
    }


    this.currentNumber += ".";
  }

  operation(op: Operation) {
    if (this.heldNumber === null) {
      this.heldNumber = parseFloat(this.currentNumber);
      this.currentNumber = "";
    } else {
      // held op is applied first
      let typedCurrentNumber = parseFloat(this.currentNumber);
      this.applyOperation();
      this.currentNumber = "";
    }

    // new op saves last
    this.heldOperation = op;
  }

  applyOperation(saveToHold: boolean = true) {
    if (this.heldOperation === null || this.heldNumber === null || this.currentNumber == null) {
      return;
    }

    let typedCurrentNumber = parseFloat(this.currentNumber);

    switch (this.heldOperation) {
      case Operation.Sum:
        this.heldNumber += typedCurrentNumber;
        break;

      case Operation.Subtract:
        this.heldNumber -= typedCurrentNumber;
        break;

      case Operation.Multiply:
        this.heldNumber *= typedCurrentNumber;
        break;

      case Operation.Divide:
        this.heldNumber /= typedCurrentNumber;
        break;
    }

    this.heldOperation = null;

    if (saveToHold) {
      this.currentNumber = "";
    } else {
      this.currentNumber = this.heldNumber.toString();
      this.heldNumber = null;
    }
  }

  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    let keyToAction : Record<string, () => void> = {
      "0":() => this.onNumberClick(0),
      "1":() => this.onNumberClick(1),
      "2":() => this.onNumberClick(2),
      "3":() => this.onNumberClick(3),
      "4":() => this.onNumberClick(4),
      "5":() => this.onNumberClick(5),
      "6":() => this.onNumberClick(6),
      "7":() => this.onNumberClick(7),
      "8":() => this.onNumberClick(8),
      "9":() => this.onNumberClick(9),
      "+":() => this.operation(Operation.Sum),
      "-":() => this.operation(Operation.Subtract),
      "*":() => this.operation(Operation.Multiply),
      "/":() => this.operation(Operation.Divide),
      "=":() => this.applyOperation(false),
      "Enter":() => this.applyOperation(false),
      "Backspace":() => this.backspace(),
    };

    let action = keyToAction[event.key];

    if (action !== undefined) {
      action();
    }
  }

  backspace() {
    if (this.currentNumber)
      this.currentNumber = this.currentNumber.substring(0, this.currentNumber.length - 1);
  }
}


enum Operation {
  Sum = 1,
  Subtract = 2,
  Multiply = 3,
  Divide = 4,
}
