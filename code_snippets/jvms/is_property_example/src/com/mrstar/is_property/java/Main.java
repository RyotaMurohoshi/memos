package com.mrstar.is_property.java;
import com.mrstar.is_property.groovy.GData;
import com.mrstar.is_property.kotlin.KData;

public class Main {
    public static void main(String[] args) {
        {
            KData data = new KData("Kotlin", false, false, false, false);

            System.out.println(data.getName());
            System.out.println(data.getEnabled0());
            System.out.println(data.isEnabled1());
            System.out.println(data.is_enabled2());
            System.out.println(data.getIsenabled3());

            data.setName("Kotlin!");
            data.setEnabled0(true);
            data.setEnabled1(true);
            data.set_enabled2(true);
            data.setIsenabled3(true);

            System.out.println(data.getName());
            System.out.println(data.getEnabled0());
            System.out.println(data.isEnabled1());
            System.out.println(data.is_enabled2());
            System.out.println(data.getIsenabled3());
        }

        {
            GData data = new GData();

            System.out.println(data.getName());
            System.out.println(data.isEnabled0());
            System.out.println(data.isIsEnabled1());
            System.out.println(data.isIs_enabled2());
            System.out.println(data.isIsenabled3());
            System.out.println(data.getEnabled0());
            System.out.println(data.getIsEnabled1());
            System.out.println(data.getIs_enabled2());
            System.out.println(data.getIsenabled3());

            data.setName("Groovy!");
            data.setEnabled0(true);
            data.setIsEnabled1(true);
            data.setIs_enabled2(true);
            data.setIsenabled3(true);

            System.out.println(data.getName());
            System.out.println(data.isEnabled0());
            System.out.println(data.isIsEnabled1());
            System.out.println(data.isIs_enabled2());
            System.out.println(data.isIsenabled3());
            System.out.println(data.getEnabled0());
            System.out.println(data.getIsEnabled1());
            System.out.println(data.getIs_enabled2());
            System.out.println(data.getIsenabled3());
        }
    }
}
