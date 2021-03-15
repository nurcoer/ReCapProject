import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car/car';
import { CarDetail } from 'src/app/models/carDetail/carDetail';
import { CarService } from 'src/app/services/Car/car.service';

//axios,fetch
@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css'],
})

//ngOninit component ilk kez açıldığında dom'a yerleştiğinde çalışan method
//constructor amacı productComponenti bellekte oluşturmaktır.
export class CarComponent implements OnInit {
  cars: Car[] = [];
  carDetails: CarDetail[] = [];
  dataLoaded=false;

  constructor(private carService: CarService) {}

  ngOnInit(): void {
    this.getCarsDetail();
  }
 
  getAll(){
     this.carService.getCars().subscribe((response)=>{
      this.cars = response.data;
      this.dataLoaded=true;
    })
  }
 
  getCarsDetail(){
    this.carService.getCarsDetail().subscribe((response)=>{
      this.carDetails = response.data;
      this.dataLoaded=true;
    })
  }
  
} 

