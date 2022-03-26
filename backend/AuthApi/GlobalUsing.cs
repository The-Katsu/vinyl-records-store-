global using System;
global using Microsoft.AspNetCore.Mvc;
global using System.Net.Mail;
global using System.Security.Claims;
global using System.Text;
global using System.Security.Cryptography;
global using System.Text.RegularExpressions;
global using System.Net;
global using System.Text.Json;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.OpenApi.Models;
global using System.ComponentModel.DataAnnotations;

global using Domain.Models;
global using AuthApi.Data;
global using AuthApi.DependencyInjections;
global using AuthApi.Application.Interfaces;
global using AuthApi.Application.Implementations;
global using AuthApi.Apis;
global using AuthApi.Application.Common.Mapping;
global using Domain.Models.DTO;
global using Domain.Models.VM;
global using AuthApi.Application.Common.JwtToken;
global using AuthApi.Application.Common.SaltHash;
global using AuthApi.Middleware;
global using AuthApi.DependencyInjections;
global using Domain.Models;

global using Microsoft.EntityFrameworkCore;
global using System.Reflection;
global using AutoMapper;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authentication.JwtBearer;



