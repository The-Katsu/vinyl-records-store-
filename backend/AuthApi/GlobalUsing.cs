global using System;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Mvc;
global using System.Net.Mail;

global using AuthApi.Models;
global using AuthApi.Data;
global using AuthApi.DependencyInjections;
global using AuthApi.Application.Interfaces;
global using AuthApi.Application.Implementations;
global using AuthApi.Apis;
global using AuthApi.Application.Common.Mapping;
global using AuthApi.Models.DTO;
global using AuthApi.Models.VM;

global using Microsoft.EntityFrameworkCore;
global using System.Reflection;
global using AutoMapper;